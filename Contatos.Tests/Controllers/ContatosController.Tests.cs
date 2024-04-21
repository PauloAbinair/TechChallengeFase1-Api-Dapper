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
            var contatos = new List<ContatoDeSaida>
            {
                new() {
                    Id = 1, Nome = "João",Email = "joao@test.com", Telefone = "993822529",
                    Regiao = new()
                    {
                        Id = 1,
                        DDD = "32",
                        UF = "MG"
                    }
                },
                new() {
                    Id = 2, Nome = "Maria", Email = "maria@test.com", Telefone = "993822529" ,
                    Regiao = new Regiao(){
                        Id = 2,
                        DDD = "11",
                        UF = "SP"
                    }
                }
            };
            _mockContatoService
                .Setup(x => x.RetornarListaDeContatos())
                .Returns(Task.FromResult<IEnumerable<ContatoDeSaida>>(contatos));

            // Act
            var result = await _contatoController.Get();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.Value, Is.EqualTo(contatos));
        }
    }
}
