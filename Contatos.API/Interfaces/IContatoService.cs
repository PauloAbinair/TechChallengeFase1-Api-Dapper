using Contatos.API.Models;

namespace Contatos.API.Interfaces
{
    public interface IContatoService
    {
        Task<Tuple<IEnumerable<Contato>, bool>> RetornarListaDeContatos(int? ddd);

        Task<Contato?> RetornarContatoPeloId(int id);

        Task<Contato> InserirNovoContato(Contato contato);

        Task<bool> ExcluirContato(int id);

        Task<bool> AlterarContato(Contato contato);
    }
}