using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contatos.API.Models
{
    [Table("Contatos")]
    public class Contato
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public required string Nome { get; set; }

        [StringLength(2, ErrorMessage = "O DDD deve ter no máximo 2 caracteres.")]
        public required string DDD { get; set; }

        [StringLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres.")]
        public required string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "O email não é válido.")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
        public required string Email { get; set; }
    }
}