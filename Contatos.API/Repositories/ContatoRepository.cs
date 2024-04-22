using System.Data.Common;
using System.Data;
using Contatos.API.Interfaces;
using Contatos.API.Models;
using Dapper.Contrib.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Dapper;

namespace Contatos.API.Repositories
{
    public class ContatoRepository(IDbConnection dbConnection) : IContatoRepository
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<bool> AlterarContato(IContato contato)
        {
            return await _dbConnection.UpdateAsync(contato as ContatoDeEntrada);
        }

        public async Task<bool> ExcluirContao(int id)
        {
            var contato = _dbConnection.Get<ContatoDeSaida>(id);
            return await _dbConnection.DeleteAsync(contato);
        }

        public async Task<IContato> InserirNovoContato(IContato contato)
        {
            contato.Id = await _dbConnection.InsertAsync(contato as ContatoDeEntrada);
            return contato;
        }

        public async Task<IEnumerable<ContatoDeSaida>> RetornarListaDeContatos(string? ddd = null)
        {
            var sql = @"SELECT CONTATOS.ID,
                               CONTATOS.NOME,
                               CONTATOS.EMAIL, 
                               CONTATOS.TELEFONE,
                               CONTATOS.IDREGIAO,
                               REGIOES.ID,
                               REGIOES.DDD,
                               REGIOES.UF
                          FROM CONTATOS
                    INNER JOIN REGIOES ON CONTATOS.IDREGIAO = REGIOES.ID
                         WHERE 1 = 1";
            ;

            object? parameters = null;

            if (ddd != null) {
                sql += "AND REGIOES.DDD = @DDD";
                parameters = new { DDD = ddd };
            }

            var contatos = await _dbConnection.QueryAsync<ContatoDeSaida, Regiao, ContatoDeSaida>(
                sql,
                (contato, regiao) =>
                {
                    contato.Regiao = regiao;
                    return contato;
                },
                parameters,
                splitOn: "IDREGIAO"
            );

            return contatos;
        }

        public async Task<ContatoDeSaida?> RetornarContatoPeloId(int id)
        {
            var contato = await _dbConnection.GetAsync<ContatoDeSaida>(id);
            return contato;
        }
    }
}
