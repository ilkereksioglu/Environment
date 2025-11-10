using EnvironmentRepository.Models.BaseModels;
using EnvironmentRepository.Models.Musteri;
using EnvironmentRepository.Repos;
using EnvironmentServices.ServiceResult;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EnvironmentServices.Services
{
    public class BaseService
    {
        protected readonly IBaseRepo _baseRepo;
        protected readonly IVeriListesiRepo _veriListesiRepo;
        public BaseService(IBaseRepo baseRepo, IVeriListesiRepo veriListesiRepo)
        {
            _baseRepo = baseRepo;
            _veriListesiRepo = veriListesiRepo;
        }

        public async Task<SirketBoundBase> GeneralizeSirketBoundTask<TDerived>(Task<TDerived> task) where TDerived : SirketBoundBase => (SirketBoundBase)await task;
        public async Task<List<SirketBoundBase>> GeneralizeSirketBoundListTask<TDerived>(Task<List<TDerived>> task) where TDerived : SirketBoundBase => new(await task);

        public async Task<ServiceResult<T>> DataGetir<T>(Expression<Func<T, bool>> func) where T : class
        {
            var entity = await _baseRepo.FirstOrDefaultAsync<T>(func);
            if (entity == null)
                return new ServiceResult<T> { Data = entity, ErrorMessage = "Musteri bulunamadi" };

            return new ServiceResult<T> { Data = entity, Succeeded = true };
        }

        public async Task<ServiceResult<T>> DataGetirSiteFiltered<T>(Expression<Func<T, bool>> func) where T : SirketBoundBase
        {
            var entity = await _baseRepo.WhereSiteFilter<T>().FirstOrDefaultAsync<T>(func);
            if (entity == null)
                return new ServiceResult<T> { Data = entity, ErrorMessage = "Musteri bulunamadi" };

            return new ServiceResult<T> { Data = entity, Succeeded = true };
        }

        public async Task<ServiceResult<List<T>>> DatalariGetir<T>(Expression<Func<T, bool>> func) where T : class
        {
            var entities = await _baseRepo.Where<T>(func).ToListAsync();
            if (entities.Count() == 0)
                return new ServiceResult<List<T>> { Data = entities, ErrorMessage = "Musteri bulunamadi" };

            return new ServiceResult<List<T>> { Data = entities, Succeeded = true };
        }
    }
}
