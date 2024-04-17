using Contatos.API.Models;

namespace Contatos.API.Interfaces
{
    public interface IRegiaoService
    {
        Task<IEnumerable<Regiao>> RetornarListaDeRegioes();
    }
}