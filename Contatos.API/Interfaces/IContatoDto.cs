using Contatos.API.Dto;
using Contatos.API.Models;

namespace Contatos.API.Interfaces
{
    public interface IContatoDto
    {

        public string Nome { get; set; }

        public int DDD { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }   
    }
}
