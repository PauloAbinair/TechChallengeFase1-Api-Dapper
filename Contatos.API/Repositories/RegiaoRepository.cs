using System.Data.Common;
using System.Data;
using Contatos.API.Interfaces;
using Contatos.API.Models;
using Dapper.Contrib.Extensions;

namespace Contatos.API.Repositories
{
    public class RegiaoRepository(IDbConnection dbConnection) : IRegiaoRepository
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<IEnumerable<Regiao>> RetornarListaDeRegioes()
        {
            var regioes = await _dbConnection.GetAllAsync<Regiao>();
            return [.. regioes];
        }
    }
}
