using System.Data;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IDbConnection _dbConnection;

        public ContatoController(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var contatos = _dbConnection.GetAll<Contato>().ToList();
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contato = _dbConnection.Get<Contato>(id);
            return contato is not null? Ok(contato) : NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contato contato)
        {
            contato.Id = (int)_dbConnection.Insert<Contato>(contato);
            return Created(string.Empty, contato);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contato contato)
        {
            contato.Id = id;
            var atualizado = _dbConnection.Update(contato);
            return atualizado? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contato = _dbConnection.Get<Contato>(id);

            if (contato is null || contato.Id.Equals(0))
                return NotFound();

            _dbConnection.Delete(contato);
            return NoContent();
        }
    }
}
