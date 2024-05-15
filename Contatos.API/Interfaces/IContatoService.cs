using Contatos.API.Models;

namespace Contatos.API.Interfaces
{
    public interface IContatoService
    {
        Task<IEnumerable<Contato>> RetornarListaDeContatos(int? ddd);

        Task<Contato?> RetornarContatoPeloId(int id);

        Task<Contato> InserirNovoContato(Contato contato);

        Task<bool> ExcluirContato(int id);

        Task<bool> AlterarContato(Contato contato);
    }
}