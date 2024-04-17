using Contatos.API.Models;

namespace Contatos.API.Interfaces
{
    public interface IRegiaoRepository
    {
        Task<IEnumerable<Regiao>> RetornarListaDeRegioes();
    }
}
