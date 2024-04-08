using Contatos.API.Models;

namespace Contatos.API.Interfaces
{
    public interface IContatoRepository
    {
        IEnumerable<Contato> RetornarListarContatos();

        Contato? RetornarContatoPeloId(int id);

        Contato InserirNovoContato(Contato contato);

        bool ExcluirContao(int id);

        bool AlterarContato(Contato contato);
    }
}
