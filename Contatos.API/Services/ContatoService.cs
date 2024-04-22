using Contatos.API.Interfaces;
using Contatos.API.Models;

namespace Contatos.API.Services
{
    public class ContatoService(IContatoRepository contatoRepository) : IContatoService
    {
        private readonly IContatoRepository _contatoRepository = contatoRepository;

        public async Task<IContato> InserirNovoContato(IContato contato)
        {
            return await _contatoRepository.InserirNovoContato(contato);
        }

        public async Task<bool> AlterarContato(IContato contato)
        {
            return await _contatoRepository.AlterarContato(contato);
        }

        public async Task<bool> ExcluirContao(int id)
        {
            return await _contatoRepository.ExcluirContao(id);
        }

        public async Task<IEnumerable<ContatoDeSaida>> RetornarListaDeContatos(string? ddd = null)
        {
            return await _contatoRepository.RetornarListaDeContatos(ddd);
        }

        public async Task<ContatoDeSaida?> RetornarContatoPeloId(int id)
        {
            return await _contatoRepository.RetornarContatoPeloId(id);
        }
    }
}
