using Contatos.API.Models;

namespace Contatos.API.Interfaces
{
    public interface ICacheService
    {
        public void DeleteKeyMemoryCache(String key);
        public void ClearMemoryCache();
        public void CreateKeyMemoryCache<T>(string key, T data);
        public bool GetDataFromMemoryCache<T>(string key, out T data);
    }
}
