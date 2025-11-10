using EnvironmentRepository.Database;
using EnvironmentRepository.Models.BaseModels;
using EnvironmentRepository.Models.Dynamic;
using EnvironmentRepository.RepoServices;
using Microsoft.EntityFrameworkCore;

namespace EnvironmentRepository.Repos
{
    public interface IVeriListesiRepo 
    {
        Task<List<VeriListesi>> VeriListesiGetir(int sirketId);
        Task<List<VeriListesi>> VeriListesiGetir(int sirketId, string className);
        Task<List<VeriListesi>> VeriListesiGetir(string className);
        Task<VeriListesi> VeriListesiGetir(int sirketId, string className, string propertyName);
        Task<List<VeriListesi>> VeriListesiGetir(string className, string propertyName);
        Task<VeriListesi> VeriListesiEkle(VeriListesi veriListesi);
    }

    public class VeriListesiRepo : BaseRepo, IVeriListesiRepo
    {
        private readonly DynamicDataCacheService _cacheService;
        public VeriListesiRepo(
            IDbContextFactory<EnvironmentDbContext> contextFactory, 
            DynamicDataCacheService cacheService, 
            EnvironmentDbContext environmentDb, 
            SiteControlModel siteControlModel) : base(environmentDb, siteControlModel, contextFactory) 
        {
            _cacheService = cacheService;
        }
        protected string CreateCacheKey(int sirketId, string className) => $"{sirketId}_{className}";
        protected string CreateSitedCacheKey(string className) => $"{string.Join(",", _siteControlModel.SirketListesi)}_{className}";
        protected string CreateCacheKey(int sirketId, string className, string propertyName) => $"{sirketId}_{className}_{propertyName}";
        protected string CreateSitedCacheKey(string className, string propertyName) => $"{string.Join(",", _siteControlModel.SirketListesi)}_{className}_{propertyName}";

        public Task<VeriListesi> VeriListesiEkle(VeriListesi veriListesi)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VeriListesi>> VeriListesiGetir(int sirketId)
        {
            var veriListesi = await _environmentDb.VeriListesi.Where(v => v.SirketId == sirketId).AsNoTracking().ToListAsync();

            return veriListesi;
        }

        public async Task<List<VeriListesi>> VeriListesiGetir(int sirketId, string className)
        {
            var cachedVeriListesi = _cacheService.GetDataByKey(CreateCacheKey(sirketId, className));
            if (cachedVeriListesi != null)
            {
                return cachedVeriListesi;
            }
            var veriListesi = await _environmentDb.VeriListesi.Where(v => v.SirketId == sirketId && v.ClassName == className).AsNoTracking().ToListAsync();
            return _cacheService.SetDataByKey(CreateCacheKey(sirketId, className), veriListesi);
        }

        public async Task<List<VeriListesi>> VeriListesiGetir(string className)
        {
            var cachedVeriListesi = _cacheService.GetDataByKey(CreateSitedCacheKey(className));
            if (cachedVeriListesi != null)
            {
                return cachedVeriListesi;
            }
            var veriListesi = await WhereSiteFilter<VeriListesi>().Where(v => v.ClassName == className).AsNoTracking().ToListAsync();
            return _cacheService.SetDataByKey(CreateSitedCacheKey(className), veriListesi);
        }

        public async Task<VeriListesi> VeriListesiGetir(int sirketId, string className, string propertyName)
        {
            var cachedVeriListesi = _cacheService.GetSingleDataByKey(CreateCacheKey(sirketId, className, propertyName));
            if (cachedVeriListesi != null)
            {
                return cachedVeriListesi;
            }
            var veriListesi = await _environmentDb.VeriListesi.SingleOrDefaultAsync(v => v.SirketId == sirketId && v.ClassName == className && v.PropertyName == propertyName);
            return _cacheService.SetSingleDataByKey(CreateCacheKey(sirketId, className, propertyName), veriListesi);
        }

        public async Task<List<VeriListesi>> VeriListesiGetir(string className, string propertyName)
        {
            var cachedVeriListesi = _cacheService.GetDataByKey(CreateSitedCacheKey(className, propertyName));
            if (cachedVeriListesi != null)
            {
                return cachedVeriListesi;
            }
            var veriListesi = await WhereSiteFilter<VeriListesi>().Where(v => v.ClassName == className && v.PropertyName == propertyName).AsNoTracking().ToListAsync();
            return _cacheService.SetDataByKey(CreateSitedCacheKey(className, propertyName), veriListesi);
        }
    }
}
