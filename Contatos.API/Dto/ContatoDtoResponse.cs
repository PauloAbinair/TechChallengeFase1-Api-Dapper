using Contatos.API.Interfaces;
using Contatos.API.Models;

namespace Contatos.API.Dto
{
    public record ContatoDtoResponse: IContatoDto
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required int DDD { get; set; }

        public required string Telefone { get; set; }

        public required string Email { get; set; }

        public RegiaoDtoResponse? Regiao { get; set; }

        public static implicit operator Contato(ContatoDtoResponse contatoDtoResponse)
        {
            var contato = new Contato()
            {
                Id = contatoDtoResponse.Id,
                Nome = contatoDtoResponse.Nome,
                DDD = contatoDtoResponse.DDD,
                Telefone = contatoDtoResponse.Telefone,
                Email = contatoDtoResponse.Email,
                Regiao = contatoDtoResponse.Regiao,
            };

            return contato;
        }
    }  
}
