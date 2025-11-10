using EnvironmentRepository.Database;
using EnvironmentRepository.Models.Kullanici;
using EnvironmentRepository.Repos;
using EnvironmentRepository.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentServices.Helpers
{
    public interface ITokenHandler
    {
        string CreateJwtToken(List<Claim> Claims = null);
        Task<string> CreateRefreshToken(int id);
        Task<(bool Succeeded, RefreshToken RefreshToken)> ValidateRefreshToken(string key);
        Task<List<Claim>> GenerateTokenClaimsAsync(Kullanici kullanici);
        Task<TokenModel> CreateTokenModelAsync(Kullanici kullanici);
        Task<string> CreateAccessTokenAsync(Kullanici kullanici);
    }

    public class JwtTokenHandler : ITokenHandler
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<Kullanici> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly IKullaniciRepo _kullaniciRepo;
        private readonly ITransaction _transaction;


        public JwtTokenHandler(
            JwtSettings jwtSettings,
            UserManager<Kullanici> userManager,
            RoleManager<Rol> roleManager,
            IKullaniciRepo kullaniciRepo,
            ITransaction transaction)
        {
            _jwtSettings = jwtSettings;
            _userManager = userManager;
            _roleManager = roleManager;
            _kullaniciRepo = kullaniciRepo;
            _transaction = transaction;
        }

        public string CreateJwtToken(List<Claim> Claims = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            /*
            (Claims = Claims ?? new List<Claim>())
                .AddRange(
                    new Claim("iss", _jwtSettings.Issuer)
                );
            */
            Claims = new List<Claim>();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.Duration),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                    SecurityAlgorithms.HmacSha256
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return jwt;
        }

        public async Task<string> CreateRefreshToken(int id)
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            var token = Convert.ToBase64String(randomNumber);
            await _kullaniciRepo.RefreshTokenEkle(token, id, DateTime.UtcNow.AddMonths(_jwtSettings.RefreshDuration));
            await _transaction.SaveChangesAsync();
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<(bool Succeeded, RefreshToken RefreshToken)> ValidateRefreshToken(string key)
        {
            var refreshToken = await _kullaniciRepo.RefreshTokenGetir(key);
            if (refreshToken is not null && refreshToken.ExpirationDate > DateTime.UtcNow)
            {
                return (true, refreshToken);
            }
            return (false, null);
        }

        public async Task<List<Claim>> GenerateTokenClaimsAsync(Kullanici kullanici)
        {
            var claims = new List<Claim>
            {
                new Claim("sub", Guid.NewGuid().ToString()),
                new Claim("name", kullanici!.UserName!),
                new Claim("email", kullanici.Email!),
                new Claim("phone", kullanici.PhoneNumber!),
            };

            if (kullanici.Sirketler != null)
                claims.Add(new Claim("sirket", kullanici.Sirketler.ToString()));

            if (kullanici.Id != 0)
            {
                var userClaims = await _userManager!.GetClaimsAsync(kullanici!);
                claims = claims.Union(userClaims).ToList();

                var roles = await _userManager.GetRolesAsync(kullanici!);
                var roleClaims = new List<Claim>();
                for (int i = 0; i < roles.Count; i++)
                {
                    roleClaims.Add(new Claim("role", roles[i]));
                    var role = await _roleManager.FindByNameAsync(roles[i]);
                    roleClaims.AddRange(await (_roleManager.GetClaimsAsync(role!)));
                }
                claims = claims.Union(roleClaims).ToList();
            }

            return claims;
        }

        public async Task<TokenModel> CreateTokenModelAsync(Kullanici kullanici) => new TokenModel
        {
            AccessToken = CreateJwtToken((await GenerateTokenClaimsAsync(kullanici)).ToList()),
            RefreshToken = await CreateRefreshToken(kullanici.Id),
        };
        public async Task<string> CreateAccessTokenAsync(Kullanici kullanici) => CreateJwtToken((await GenerateTokenClaimsAsync(kullanici)).ToList());
    }

    public class TokenModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }

    public class AccessTokenModel
    {
        public string AccessToken { get; set; }
    }

    public class AccessTokenGetirModel
    {
        public string RefreshToken { get; set; }
    }

    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int Duration { get; set; }
        public int RefreshDuration { get; set; }
    }
}
