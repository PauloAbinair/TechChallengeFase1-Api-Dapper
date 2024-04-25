using Contatos.API.Dto;
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

        /// <summary>
        /// Retorna a lista de todos contatos cadastrados
        /// </summary>
        /// <param name="ddd">(Opcional) Informar para retornar contatos filtrados por DDD</param>
        /// <returns name="ContatoDto"></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? ddd)
        {
            var contatos = await _contatoService.RetornarListaDeContatos(ddd);
            var contatosDto = contatos.Select(contato => (ContatoDto)contato);
            return Ok(contatosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contato = await _contatoService.RetornarContatoPeloId(id);
            return contato is not null ? Ok((ContatoDto)contato) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContatoDto contatoDto)
        {
            var contato = (Contato)contatoDto;
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
