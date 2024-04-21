using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contatos.API.Interfaces;

namespace Contatos.API.Models
{
    [Table("Contatos")]
    public record ContatoDeEntrada : IContato
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Deve ser informado um ID de região")]
        public required int IdRegiao { get; set; }

        [StringLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres.")]
        [Phone(ErrorMessage = "Número de telefone inválido.")]
        public required string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "O email não é válido.")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
        public required string Email { get; set; }
    }
}
