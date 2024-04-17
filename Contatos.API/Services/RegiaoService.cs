using Contatos.API.Interfaces;
using Contatos.API.Models;

namespace Contatos.API.Services
{
    public class RegiaoService(IRegiaoRepository regiaoServiceRepository) : IRegiaoService
    {
        private readonly IRegiaoRepository _regiaoServiceRepository = regiaoServiceRepository;

        public async Task<IEnumerable<Regiao>> RetornarListaDeRegioes()
        {
            return await _regiaoServiceRepository.RetornarListaDeRegioes();
        }
    }
}
