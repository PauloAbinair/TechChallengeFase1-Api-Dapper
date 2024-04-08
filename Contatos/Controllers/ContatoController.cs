using Contatos.API.Interfaces;
using Contatos.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatosController(IContatoRepository contatoRepository) : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository = contatoRepository;

        [HttpGet]
        public IActionResult Get()
        {
            var contatos = _contatoRepository.RetornarListaDeContatos();
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contato = _contatoRepository.RetornarContatoPeloId(id);
            return contato is not null ? Ok(contato) : NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contato contato)
        {
            var novoContato = _contatoRepository.InserirNovoContato(contato);
            return Created(string.Empty, novoContato);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contato contato)
        {
            contato.Id = id;
            var atualizado = _contatoRepository.AlterarContato(contato);
            return atualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contatoRepository.ExcluirContao(id);
            return NoContent();
        }
    }
}
