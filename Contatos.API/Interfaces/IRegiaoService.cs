using Contatos.API.Models;

namespace Contatos.API.Interfaces
{
    public interface IRegiaoService
    {
        Task<Tuple<IEnumerable<Regiao>, bool>> RetornarListaDeRegioes();
    }
}