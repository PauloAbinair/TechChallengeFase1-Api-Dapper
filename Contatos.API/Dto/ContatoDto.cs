using Contatos.API.Models;

namespace Contatos.API.Dto
{
    public record ContatoDto
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required int IdRegiao { get; set; }

        public required string Telefone { get; set; }

        public required string Email { get; set; }

        public Regiao? Regiao { get; set; }

        public static implicit operator Contato(ContatoDto contatoDto)
        {
            var contato = new Contato()
            {
                Id = contatoDto.Id,
                Nome = contatoDto.Nome,
                IdRegiao = contatoDto.IdRegiao,
                Telefone = contatoDto.Telefone,
                Email = contatoDto.Email,
                Regiao = contatoDto.Regiao
             };

            return contato;
        }
    }  
}
