using System.Data;
using Contatos.API.Interfaces;
using Contatos.API.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Caching.Memory;

namespace Contatos.API.Repositories
{
    public class RegiaoRepository(IDbConnection dbConnection, IMemoryCache cache) : IRegiaoRepository
    {
        private readonly IDbConnection _dbConnection = dbConnection;
        private readonly IMemoryCache _cache = cache;

        public async Task<IEnumerable<Regiao>> RetornarListaDeRegioes()
        {
            if (!_cache.TryGetValue("regiao", out IEnumerable<Regiao> listaCacheada))
            {
                var regioes = await _dbConnection.GetAllAsync<Regiao>();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(120));

                _cache.Set("regiao", regioes, cacheEntryOptions);

                return [.. regioes];
            }

            return listaCacheada;
        }
    }
}
