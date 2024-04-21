﻿using Contatos.API.Models;

namespace Contatos.API.Interfaces
{
    public interface IContatoService
    {
        Task<IEnumerable<ContatoDeSaida>> RetornarListaDeContatos();

        Task<ContatoDeSaida?> RetornarContatoPeloId(int id);

        Task<IContato> InserirNovoContato(IContato contato);

        Task<bool> ExcluirContao(int id);

        Task<bool> AlterarContato(IContato contato);
    }
}