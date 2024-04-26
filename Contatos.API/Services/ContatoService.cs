using Contatos.API.Interfaces;
using Contatos.API.Models;

namespace Contatos.API.Services
{
    public class ContatoService(IContatoRepository contatoRepository) : IContatoService
    {
        private readonly IContatoRepository _contatoRepository = contatoRepository;

        public async Task<Contato> InserirNovoContato(Contato contato)
        {
            return await _contatoRepository.InserirNovoContato(contato);
        }

        public async Task<bool> AlterarContato(Contato contato)
        {
            return await _contatoRepository.AlterarContato(contato);
        }

        public async Task<bool> ExcluirContao(int id)
        {
            return await _contatoRepository.ExcluirContao(id);
        }

        public async Task<IEnumerable<Contato>> RetornarListaDeContatos(int? ddd)
        {
            return await _contatoRepository.RetornarListaDeContatos(ddd);
        }

        public async Task<Contato?> RetornarContatoPeloId(int id)
        {
            return await _contatoRepository.RetornarContatoPeloId(id);
        }
    }
}
