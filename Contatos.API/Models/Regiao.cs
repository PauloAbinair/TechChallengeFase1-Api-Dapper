using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contatos.API.Models
{
    [Table("Regioes")]
    public class Regiao
    {
        [Dapper.Contrib.Extensions.Key]
        [Required(ErrorMessage = "O código DDD é obrigatório.")]
        public required int DDD { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório.")]
        public required string UF { get; set; }
    }
}
