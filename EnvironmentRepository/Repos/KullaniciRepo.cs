using EnvironmentRepository.Database;
using EnvironmentRepository.Models.BaseModels;
using EnvironmentRepository.Models.Kullanici;
using EnvironmentRepository.Models.Musteri;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentRepository.Repos
{
    public interface IKullaniciRepo
    {
        Task<RefreshToken> RefreshTokenGetir(string key);
        Task<RefreshToken> RefreshTokenEkle(string key, int kullaniciId, DateTime expirationDate);
    }

    public class KullaniciRepo : BaseRepo, IKullaniciRepo
    {
        public KullaniciRepo(
            EnvironmentDbContext environmentDb, 
            SiteControlModel siteControlModel, 
            IDbContextFactory<EnvironmentDbContext> contextFactory) : base(environmentDb, siteControlModel, contextFactory) 
        {
        
        }

        public async Task<RefreshToken> RefreshTokenGetir(string key)
        {
            var token = await _environmentDb.RefreshToken.Include(r => r.Kullanici).FirstOrDefaultAsync(r => r.Key == key);
            return token;
        }

        public async Task<RefreshToken> RefreshTokenEkle(string key, int kullaniciId, DateTime expirationDate)
        {
            var token = new RefreshToken { Key = key, KullaniciId = kullaniciId, ExpirationDate = expirationDate };
            await _environmentDb.RefreshToken.AddAsync(token);
            return token;
        }
    }
}
