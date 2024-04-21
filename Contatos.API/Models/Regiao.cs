using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contatos.API.Models
{
    [Table("Regioes")]
    public class Regiao
    {
        [Key]
        public int Id { get; set; }

        [StringLength(2, ErrorMessage = "O DDD deve ter no máximo 2 caracteres.")]
        public required string DDD { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório.")]
        public required string UF { get; set; }
    }
}
