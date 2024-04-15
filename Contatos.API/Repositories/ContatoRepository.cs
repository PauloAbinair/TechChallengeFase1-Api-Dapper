using System.Data.Common;
using System.Data;
using Contatos.API.Interfaces;
using Contatos.API.Models;
using Dapper.Contrib.Extensions;

namespace Contatos.API.Repositories
{
    public class ContatoRepository(IDbConnection dbConnection) : IContatoRepository
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<bool> AlterarContato(Contato contato)
        {
            return await _dbConnection.UpdateAsync(contato);
        }

        public async Task<bool> ExcluirContao(int id)
        {
            var contato = _dbConnection.Get<Contato>(id);
            return await _dbConnection.DeleteAsync(contato);
        }

        public async Task<Contato> InserirNovoContato(Contato contato)
        {
            contato.Id = await _dbConnection.InsertAsync(contato);
            return contato;
        }

        public async Task<IEnumerable<Contato>> RetornarListaDeContatos()
        {
            var contatos = await _dbConnection.GetAllAsync<Contato>();
            return [.. contatos];
        }

        public async Task<Contato?> RetornarContatoPeloId(int id)
        {
            var contato = await _dbConnection.GetAsync<Contato>(id);
            return contato;
        }
    }
}
