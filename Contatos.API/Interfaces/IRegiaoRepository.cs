using Contatos.API.Models;

namespace Contatos.API.Interfaces
{
    public interface IRegiaoRepository
    {
        Task<Tuple<IEnumerable<Regiao>, bool>> RetornarListaDeRegioes();
    }
}
