using Contatos.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Contatos.API.Interfaces
{ 
    public interface IContato
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }
    }
}
