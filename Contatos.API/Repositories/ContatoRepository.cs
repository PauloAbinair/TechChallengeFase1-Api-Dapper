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

        public bool AlterarContato(Contato contato)
        {
            return _dbConnection.Update(contato);
        }

        public bool ExcluirContao(int id)
        {
            var contato = _dbConnection.Get<Contato>(id);
            return _dbConnection.Delete(contato);
        }

        public Contato InserirNovoContato(Contato contato)
        {
            contato.Id = (int)_dbConnection.Insert(contato);
            return contato;
        }

        public IEnumerable<Contato> RetornarListaDeContatos()
        {
            var contatos = _dbConnection.GetAll<Contato>().ToList();
            return [.. contatos];
        }

        public Contato? RetornarContatoPeloId(int id)
        {
            var contato = _dbConnection.Get<Contato>(id);
            return contato;
        }
    }
}
