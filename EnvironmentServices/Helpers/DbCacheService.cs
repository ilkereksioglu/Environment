using EnvironmentRepository.Repos;
using Microsoft.Extensions.Caching.Memory;

namespace EnvironmentServices.Helpers
{
    public class DbCacheService
    {
        private readonly IVeriListesiRepo _veriListesiRepo;
        private readonly IMemoryCache _cache;

        public DbCacheService(IMemoryCache cache, IVeriListesiRepo veriListesiRepo)
        {
            _cache = cache;
            _veriListesiRepo = veriListesiRepo;
        }
    }
}
