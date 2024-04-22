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

        private List<ContatoDeSaida> _mockListaDeContatos = [
                new() {
                    Id = 1, Nome = "João",Email = "joao@test.com", Telefone = "995678721",
                    Regiao = new()
                    {
                        Id = 1,
                        DDD = "32",
                        UF = "MG"
                    }
                },
                new() {
                    Id = 2, Nome = "Maria", Email = "maria@test.com", Telefone = "99764326" ,
                    Regiao = new Regiao(){
                        Id = 2,
                        DDD = "11",
                        UF = "SP"
                    }
                },
                new() {
                    Id = 2, Nome = "José", Email = "jose@test.com", Telefone = "309882983" ,
                    Regiao = new Regiao(){
                        Id = 2,
                        DDD = "11",
                        UF = "SP"
                    }
                }
        ];


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
            _mockContatoService
                .Setup(x => x.RetornarListaDeContatos(null))
                .Returns(Task.FromResult<IEnumerable<ContatoDeSaida>>(_mockListaDeContatos));

            // Act
            var result = await _contatoController.Get();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.Value, Is.EqualTo(_mockListaDeContatos));
        }

        [Test]
        public async Task Deve_Retornar_Contatos_Filtrados_Por_DDD()
        {
            // Arrange
            var ddd = "11";
            var contatosFiltrados = _mockListaDeContatos.Where(contato => contato.Regiao.DDD == ddd);
            _mockContatoService
                .Setup(x => x.RetornarListaDeContatos(ddd))
                .Returns(Task.FromResult(contatosFiltrados));

            // Act
            var result = await _contatoController.Get(ddd);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.Value, Is.EqualTo(contatosFiltrados));
        }
    }
}
