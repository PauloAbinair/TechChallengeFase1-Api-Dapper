using Contatos.API.Interfaces;
using Contatos.API.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Contatos.API.Services
{
    public class CacheService(IMemoryCache cache) : ICacheService
    {
        private readonly IMemoryCache _cache = cache;

        public void ClearMemoryCache()
        {
            this.DeleteKeyMemoryCache("regiao");
            this.DeleteKeyMemoryCache("contato");
        }
        public void DeleteKeyMemoryCache(string key)
        {
            _cache.Remove(key);
        }
        public void CreateKeyMemoryCache<T>(string key, T data)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                   .SetSlidingExpiration(TimeSpan.FromMinutes(120));

            _cache.Set(key, data, cacheEntryOptions);
        }
        public bool GetDataFromMemoryCache<T>(string key, out T data)
        {
            _cache.TryGetValue(key, out data);
            return data != null;
        }
    }
}
