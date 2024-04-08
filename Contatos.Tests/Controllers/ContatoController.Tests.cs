using Contatos.Controllers;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Moq;
using System.Data;

namespace Contatos.API.Tests.Controllers
{
    [TestFixture]
    public class ContatoControllerTests
    {
        private Mock<IDbConnectionFactory> _mockDbConnectionFactory;
        private ContatoController _contatoController;

        [SetUp]
        public void Setup()
        {
            {
                _mockDbConnectionFactory = new Mock<IDbConnectionFactory>();
                var mockDbConnection = new Mock<IDbConnection>();
                mockDbConnection.Setup(x => x.GetAll<Contato>(null, null)).Returns(new List<Contato>());
                _mockDbConnectionFactory.Setup(x => x.CreateConnection()).Returns(mockDbConnection.Object);
                _contatoController = new ContatoController(_mockDbConnectionFactory.Object.CreateConnection());
            }
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
            var mockDbConnection = (Mock<IDbConnection>)_mockDbConnectionFactory.Object.CreateConnection();
            mockDbConnection.Setup(x => x.GetAll<Contato>(null, null)).Returns(contatos);

            // Act
            var result = _contatoController.Get();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.Value, Is.EqualTo(contatos));
        }

        public interface IDbConnectionFactory
        {
            IDbConnection CreateConnection();
        }

        public class DbConnectionFactory : IDbConnectionFactory
        {
            private readonly string _connectionString;

            public DbConnectionFactory(string connectionString)
            {
                _connectionString = connectionString;
            }

            public IDbConnection CreateConnection()
            {
                return new SqlConnection(_connectionString);
            }
        }
    }
}
