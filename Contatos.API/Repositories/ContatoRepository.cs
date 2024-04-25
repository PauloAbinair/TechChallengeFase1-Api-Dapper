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

        public async Task<bool> AlterarContato(Contato contato)
        {
            return await _dbConnection.UpdateAsync(contato as Contato);
        }

        public async Task<bool> ExcluirContao(int id)
        {
            var contato = _dbConnection.Get<Contato>(id);
            return await _dbConnection.DeleteAsync(contato);
        }

        public async Task<Contato> InserirNovoContato(Contato contato)
        {
            contato.Id = await _dbConnection.InsertAsync(contato as Contato);
            return contato;
        }

        public async Task<IEnumerable<Contato>> RetornarListaDeContatos(string? ddd)
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

            var contatos = await _dbConnection.QueryAsync<Contato, Regiao, Contato>(
                sql,
                (contato, regiao) =>
                {
                    contato.IdRegiao = regiao.Id;
                    contato.Regiao = regiao;
                    return contato;
                },
                parameters,
                splitOn: "IDREGIAO"
            );

            return contatos;
        }

        public async Task<Contato?> RetornarContatoPeloId(int id)
        {
            var contato = await _dbConnection.GetAsync<Contato>(id);
            return contato;
        }
    }
}
