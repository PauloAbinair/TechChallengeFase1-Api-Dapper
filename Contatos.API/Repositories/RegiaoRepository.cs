using Contatos.API.Interfaces;
using Contatos.API.Models;

namespace Contatos.API.Repositories
{
    public class RegiaoRepository : IRegiaoRepository
    {
        public Task<IEnumerable<Regiao>> RetornarListaDeRegioes()
        {
            return Task.FromResult(regioes);
        }

        private readonly IEnumerable<Regiao> regioes =
        [
            new() { DDD = "11", UF = "SP" },
            new() { DDD = "12", UF = "SP" },
            new() { DDD = "13", UF = "SP" },
            new() { DDD = "14", UF = "SP" },
            new() { DDD = "15", UF = "SP" },
            new() { DDD = "16", UF = "SP" },
            new() { DDD = "17", UF = "SP" },
            new() { DDD = "18", UF = "SP" },
            new() { DDD = "19", UF = "SP" },
            new() { DDD = "21", UF = "RJ" },
            new() { DDD = "22", UF = "RJ" },
            new() { DDD = "24", UF = "RJ" },
            new() { DDD = "27", UF = "ES" },
            new() { DDD = "28", UF = "ES" },
            new() { DDD = "31", UF = "MG" },
            new() { DDD = "32", UF = "MG" },
            new() { DDD = "33", UF = "MG" },
            new() { DDD = "34", UF = "MG" },
            new() { DDD = "35", UF = "MG" },
            new() { DDD = "37", UF = "MG" },
            new() { DDD = "38", UF = "MG" },
            new() { DDD = "41", UF = "PR" },
            new() { DDD = "42", UF = "PR" },
            new() { DDD = "43", UF = "PR" },
            new() { DDD = "44", UF = "PR" },
            new() { DDD = "45", UF = "PR" },
            new() { DDD = "46", UF = "PR" },
            new() { DDD = "47", UF = "SC" },
            new() { DDD = "48", UF = "SC" },
            new() { DDD = "49", UF = "SC" },
            new() { DDD = "51", UF = "RS" },
            new() { DDD = "53", UF = "RS" },
            new() { DDD = "54", UF = "RS" },
            new() { DDD = "55", UF = "RS" },
            new() { DDD = "61", UF = "DF" },
            new() { DDD = "62", UF = "GO" },
            new() { DDD = "63", UF = "TO" },
            new() { DDD = "64", UF = "GO" },
            new() { DDD = "65", UF = "MT" },
            new() { DDD = "66", UF = "MT" },
            new() { DDD = "67", UF = "MS" },
            new() { DDD = "68", UF = "AC" },
            new() { DDD = "69", UF = "RO" },
            new() { DDD = "71", UF = "BA" },
            new() { DDD = "73", UF = "BA" },
            new() { DDD = "74", UF = "BA" },
            new() { DDD = "75", UF = "BA" },
            new() { DDD = "77", UF = "BA" },
            new() { DDD = "79", UF = "SE" },
            new() { DDD = "81", UF = "PE" },
            new() { DDD = "82", UF = "AL" },
            new() { DDD = "83", UF = "PB" },
            new() { DDD = "84", UF = "RN" },
            new() { DDD = "85", UF = "CE" },
            new() { DDD = "86", UF = "PI" },
            new() { DDD = "87", UF = "PE" },
            new() { DDD = "88", UF = "CE" },
            new() { DDD = "89", UF = "PI" },
            new() { DDD = "91", UF = "PA" },
            new() { DDD = "92", UF = "AM" },
            new() { DDD = "93", UF = "PA" },
            new() { DDD = "94", UF = "PA" },
            new() { DDD = "95", UF = "RR" },
            new() { DDD = "96", UF = "AP" },
            new() { DDD = "97", UF = "AM" },
            new() { DDD = "98", UF = "MA" },
            new() { DDD = "99", UF = "MA" }
       ];
    }
}
