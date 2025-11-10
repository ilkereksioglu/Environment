using EnvironmentRepository.Models.Dynamic;
using Microsoft.Extensions.Caching.Memory;

namespace EnvironmentRepository.RepoServices
{
    public class DynamicDataCacheService
    {
        private readonly IMemoryCache _cache;
        public DynamicDataCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public VeriListesi GetSingleDataByKey(string key)
        {
            if (_cache.TryGetValue<VeriListesi>(key, out VeriListesi veriListesi))
            {
                return veriListesi;
            }
            else
            {
                return null;
            }
        }

        public VeriListesi SetSingleDataByKey(string key, VeriListesi veriListesi) => _cache.Set<VeriListesi>(key, veriListesi);

        public List<VeriListesi> GetDataByKey(string key)
        {
            if(_cache.TryGetValue<List<VeriListesi>>(key, out List<VeriListesi> veriListeleri))
            {
                return veriListeleri;
            }
            else
            {
                return null;
            }
        }

        public List<VeriListesi> SetDataByKey(string key, List<VeriListesi> veriListesi) => _cache.Set<List<VeriListesi>>(key, veriListesi);
    }
}
