using Contatos.API.Interfaces;
using Contatos.API.Models;

namespace Contatos.API.Dto
{
    public record RegiaoDtoResponse : IRegiaoDto
    {
        public required int DDD { get; set; }

        public required string UF { get; set; }

        public static implicit operator Regiao(RegiaoDtoResponse regiaoDtoResponse)
        {
            var regiao = new Regiao()
            {
                DDD = regiaoDtoResponse.DDD,
                UF = regiaoDtoResponse.UF
            };

            return regiao;
        }
    }
}
