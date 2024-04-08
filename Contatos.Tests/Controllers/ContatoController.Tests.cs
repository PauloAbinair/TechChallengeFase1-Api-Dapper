using Contatos.API.Interfaces;
using Contatos.API.Models;
using Contatos.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Contatos.API.Tests.Controllers
{
    [TestFixture]
    public class ContatoControllerTests
    {
        private ContatosController _contatoController;
        private Mock<IContatoRepository> _mockContatoRepository;

        [SetUp]
        public void Setup()
        {
            _mockContatoRepository = new Mock<IContatoRepository>();
            _contatoController = new ContatosController(_mockContatoRepository.Object);
        }

        [Test]
        public void Deve_Retornar_Ok_Para_Get_Contatos()
        {
            // Arrange
            var contatos = new List<Contato>
            {
                new() { Id = 1, Nome = "João", DDD = "31", Email = "joao@test.com", Telefone = "993822529" },
                new() { Id = 2, Nome = "Maria", DDD = "11", Email = "maria@test.com", Telefone = "993822529" }
            };
            _mockContatoRepository.Setup(x => x.RetornarListaDeContatos()).Returns(contatos);

            // Act
            var result = _contatoController.Get();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.Value, Is.EqualTo(contatos));
        }
    }
}
