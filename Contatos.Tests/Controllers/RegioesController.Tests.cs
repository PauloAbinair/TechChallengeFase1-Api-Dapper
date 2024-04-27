using Contatos.API.Controllers;
using Contatos.API.Dto;
using Contatos.API.Interfaces;
using Contatos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Contatos.API.Tests.Controllers
{
    [TestFixture]
    public class RegiaoControllerTests
    {
        private RegioesController _regiaoController;
        private Mock<IRegiaoService> _mockRegiaoService;

        [SetUp]
        public void Setup()
        {
            _mockRegiaoService = new Mock<IRegiaoService>();
            _regiaoController = new RegioesController(_mockRegiaoService.Object);
        }

        [Test]
        public async Task Deve_Retornar_A_Lista_De_Regioes_De_DDD()
        {
            // Arrange
            var mockListaDeRegioes = new List<RegiaoDtoResponse>
            {
                new() { DDD = 31, UF = "MG"},
                new() { DDD = 11, UF = "SP"},
            };

            var regioes = mockListaDeRegioes
                .Select(regiaoDto => (Regiao)regiaoDto);

            _mockRegiaoService
                .Setup(x => x.RetornarListaDeRegioes())
                .Returns(Task.FromResult<IEnumerable<Regiao>>(regioes));

            // Act
            var result = await _regiaoController.GetAll();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.Value, Is.EqualTo(mockListaDeRegioes));
        }
    }
}
