using Contatos.API.Controllers;
using Contatos.API.Interfaces;
using Contatos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Contatos.API.Tests.Controllers
{
    [TestFixture]
    public class ContatosControllerTests
    {
        private ContatosController _contatoController;
        private Mock<IContatoService> _mockContatoService;

        [SetUp]
        public void Setup()
        {
            _mockContatoService = new Mock<IContatoService>();
            _contatoController = new ContatosController(_mockContatoService.Object);
        }

        [Test]
        public async Task Deve_Retornar_Ok_Para_Get_Contatos()
        {
            // Arrange
            var contatos = new List<Contato>
            {
                new() { Id = 1, Nome = "João", DDD = "31", Email = "joao@test.com", Telefone = "993822529" },
                new() { Id = 2, Nome = "Maria", DDD = "11", Email = "maria@test.com", Telefone = "993822529" }
            };
            _mockContatoService.Setup(x => x.RetornarListaDeContatos()).Returns(Task.FromResult<IEnumerable<Contato>>(contatos));

            // Act
            var result = await _contatoController.Get();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.Value, Is.EqualTo(contatos));
        }
    }
}
