using Contatos.API.Interfaces;
using Contatos.API.Models;

namespace Contatos.API.Dto
{
    public record ContatoDtoRequest
    {   
        public required string Nome { get; set; }

        public required int DDD { get; set; }

        public required string Telefone { get; set; }

        public required string Email { get; set; }

        public static implicit operator Contato(ContatoDtoRequest contatoDtoRequest)
        {
            var contato = new Contato()
            {                
                Nome = contatoDtoRequest.Nome,
                DDD = contatoDtoRequest.DDD,
                Telefone = contatoDtoRequest.Telefone,
                Email = contatoDtoRequest.Email,
             };

            return contato;
        }
    }  
}
