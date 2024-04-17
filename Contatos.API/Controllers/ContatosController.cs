using Contatos.API.Interfaces;
using Contatos.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatosController(IContatoService contatoService) : ControllerBase
    {
        private readonly IContatoService _contatoService = contatoService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var contatos = await _contatoService.RetornarListaDeContatos();
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var contato = await _contatoService.RetornarContatoPeloId(id);
            return contato is not null ? Ok(contato) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contato contato)
        {
            var novoContato = await _contatoService.InserirNovoContato(contato);
            return Created(string.Empty, novoContato);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Contato contato)
        {
            contato.Id = id;
            var atualizado = await _contatoService.AlterarContato(contato);
            return atualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contatoService.ExcluirContao(id);
            return NoContent();
        }
    }
}
