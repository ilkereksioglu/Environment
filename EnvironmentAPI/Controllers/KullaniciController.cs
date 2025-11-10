using EnvironmentAPI.Filters;
using EnvironmentAPI.Models.Kullanici;
using EnvironmentAPI.Models.Response;
using EnvironmentRepository.Models.Kullanici;
using EnvironmentServices.Helpers;
using EnvironmentServices.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EnvironmentAPI.Controllers
{
    [ApiController]
    public class KullaniciController : Controller
    {
        private readonly UserManager<Kullanici> _userManager;
        private readonly SignInManager<Kullanici> _signInManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly ITokenHandler _jwtTokenHandler;
        private readonly IKullaniciService _kullaniciService;
        public KullaniciController(
            UserManager<Kullanici> userManager,
            SignInManager<Kullanici> signInManager,
            RoleManager<Rol> roleManager,
            ITokenHandler tokenHandler,
            IKullaniciService kullaniciService
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtTokenHandler = tokenHandler;
            _kullaniciService = kullaniciService;
        }

        [HttpPost]
        [Route(Routing.GirisYap)]
        public async Task<IActionResult> GirisYap(GirisYapModel model)
        {
            var kullanici = await _userManager.FindByNameAsync(model.KullaniciAdi);
            if (kullanici == null)
                return Unauthorized();
            var isValidPassword = await _userManager.CheckPasswordAsync(kullanici, model.Password);
            if (isValidPassword)
            {
                var tokenModel = await _jwtTokenHandler.CreateTokenModelAsync(kullanici);
                return Ok(tokenModel);
            }
            return BadRequest("Hatali giris!");
        }

        [HttpPost]
        [Route(Routing.TokenGetir)]
        public async Task<IActionResult> AccessTokenGetir(AccessTokenGetirModel model)
        {
            var tokenResult = await _kullaniciService.RefreshTokenGetir(model.RefreshToken);
            if (tokenResult.Succeeded)
            {
                var accessToken = await _jwtTokenHandler.CreateAccessTokenAsync(tokenResult.Data.Kullanici);
                return Ok(new ApiResponse<TokenModel> { Data = new TokenModel { AccessToken = accessToken, RefreshToken = model.RefreshToken }, Succeeded = true });
            }
            else if (tokenResult.Data == null)
            {
                return Unauthorized(new ApiResponse<TokenModel>(null));
            }

            return BadRequest(new ApiResponse<TokenModel>(null));
        }

        [HttpPost]
        [RequireClaim("SuperAdmin", "true")]
        [Route(Routing.KayitOl)]
        public IActionResult KayitOl(KayitOlModel model)
        {
            //await _userManager.CreateAsync();
            return View();
        }

        [HttpGet]
        [Route(Routing.KayitTest)]
        public async Task<IActionResult> KayitTest()
        {
            var kullanici = await _userManager.FindByNameAsync("Ilker");;
            var r = await _roleManager.CreateAsync(new Rol { Name = "SuperAdmin" });
            await _userManager.AddToRoleAsync(kullanici, "SuperAdmin");
            var claims = new List<Claim>();
            claims.Add(new Claim("SuperAdmin", "true"));
            //await _userManager.AddClaimsAsync(kullanici, claims);
            return Ok(kullanici);
        }
    }
}
