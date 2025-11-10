using EnvironmentRepository.Models.Dynamic;
using EnvironmentRepository.Repos;
using EnvironmentRepository.UnitOfWork;
using EnvironmentServices.ServiceResult;
using Microsoft.EntityFrameworkCore;

namespace EnvironmentServices.Services
{
    public interface IVeriListesiService
    {

    }

    public class VeriListesiService : BaseService, IVeriListesiService
    {
        private readonly IVeriListesiRepo _veriListesiRepo;
        private readonly ITransaction _transaction;
        public VeriListesiService(IBaseRepo baseRepo, IVeriListesiRepo veriListesiRepo, ITransaction transaction) : base(baseRepo, veriListesiRepo)
        {
            _veriListesiRepo = veriListesiRepo;
            _transaction = transaction;
        }

        public async Task<ServiceResult<List<VeriListesi>>> VeriListesiniGetir(int siteId)
        {
            var veriler = await _veriListesiRepo.VeriListesiGetir(siteId);

            return new ServiceResult<List<VeriListesi>> { Data = veriler, Succeeded = true };
        }

        public async Task<ServiceResult<List<VeriListesi>>> TumVeriListesiniGetir()
        {
            var veriler = await _baseRepo.GetAllAsyncFiltered<VeriListesi>();

            return new ServiceResult<List<VeriListesi>> { Data = veriler, Succeeded = true };
        }

    }
}
