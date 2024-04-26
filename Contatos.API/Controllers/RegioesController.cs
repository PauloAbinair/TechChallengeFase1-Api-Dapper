using Contatos.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegioesController(IRegiaoService regiaoService) : ControllerBase
    {
        private readonly IRegiaoService _regiaoService = regiaoService;

        /// <summary>
        /// Retorna a lista de DDD's
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var regioes = await _regiaoService.RetornarListaDeRegioes();
            return Ok(regioes);
        }
    }
}