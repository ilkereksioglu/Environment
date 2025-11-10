using EnvironmentRepository.Models.Kullanici;
using EnvironmentRepository.Models.Musteri;
using EnvironmentRepository.Repos;
using EnvironmentRepository.UnitOfWork;
using EnvironmentServices.DTO.MusteriDTO;
using EnvironmentServices.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentServices.Services
{
    public interface IKullaniciService
    {
        public Task<ServiceResult<RefreshToken>> RefreshTokenGetir(string key);
        public Task<ServiceResult<RefreshToken>> RefreshTokenEkle(string key, int kullaniciId, DateTime expirationDate);
    }
    public class KullaniciService : BaseService, IKullaniciService
    {
        private readonly IKullaniciRepo _kullaniciRepo;
        private readonly ITransaction _transaction;
        public KullaniciService(IBaseRepo baseRepo, IVeriListesiRepo veriListesiRepo, IKullaniciRepo kullaniciRepo, ITransaction transaction) : base(baseRepo, veriListesiRepo)
        {
            _kullaniciRepo = kullaniciRepo;
            _transaction = transaction;
        }

        public async Task<ServiceResult<RefreshToken>> RefreshTokenEkle(string key, int kullaniciId, DateTime expirationDate)
        {
            var token = await _kullaniciRepo.RefreshTokenEkle(key, kullaniciId, expirationDate);
            await _transaction.SaveChangesAsync();
            return new ServiceResult<RefreshToken> { Data = token, Succeeded = true };
        }

        public async Task<ServiceResult<RefreshToken>> RefreshTokenGetir(string key)
        {
            var token = await _kullaniciRepo.RefreshTokenGetir(key);
            if(token == null)
                return new ServiceResult<RefreshToken> { ErrorMessage = "Token bulunamadi", Succeeded = false };
            if (token.ExpirationDate > DateTime.Now)
                return new ServiceResult<RefreshToken> { Data = token, Succeeded = true };
            return new ServiceResult<RefreshToken> { ErrorMessage = "Token suresi doldu", Succeeded = false };

        }
    }
}
