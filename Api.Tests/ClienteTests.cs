using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VendasMedicamentos.Controllers;
using VendasMedicamentos.Models.Dtos;
using VendasMedicamentos.Models.Entities;
using VendasMedicamentos.Repository.Interfaces;

namespace Api.Tests
{
    public class ClienteTests
    {
        [Fact]
        public async Task GetClientes_DeveRetornarTodosClientes()
        {
            var mockRepository = new Mock<IClienteRepository>();
            var mockMapper = new Mock<IMapper>();

            var clientesEsperados = new List<ClienteDto>() { new ClienteDto(), new ClienteDto() };
            mockRepository.Setup(repo => repo.GetClientesAsync()).ReturnsAsync(clientesEsperados);

            var controlador = new ClienteController(mockRepository.Object, mockMapper.Object);

            var resultadoAcao = await controlador.Get();

            Assert.IsType<OkObjectResult>(resultadoAcao); 
            var resultadoOk = resultadoAcao as OkObjectResult;
            Assert.NotNull(resultadoOk); 
            Assert.Equal(clientesEsperados, resultadoOk.Value);
        }

        [Fact]
        public async Task GetById_RetornarClientePorId()
        {
            int clienteId = 1;
            var mockRepository = new Mock<IClienteRepository>();
            var mockMapper = new Mock<IMapper>();

            var clienteEsperado = new Cliente { Id = clienteId, Nome = "Cliente Teste", Email = "email@teste.com" };
            mockRepository.Setup(repo => repo.GetClienteByIdAsync(clienteId)).ReturnsAsync(clienteEsperado);

            var controlador = new ClienteController(mockRepository.Object, mockMapper.Object);

            var resultadoAcao = await controlador.GetById(clienteId);

            Assert.IsType<OkObjectResult>(resultadoAcao);
            var resultadoOk = resultadoAcao as OkObjectResult;
            Assert.NotNull(resultadoOk);
            
            var clienteRetornado = resultadoOk.Value as Cliente;
            Assert.NotNull(clienteRetornado);
           
            Assert.Equal(clienteEsperado.Id, clienteRetornado.Id);
            Assert.Equal(clienteEsperado.Nome, clienteRetornado.Nome);
            Assert.Equal(clienteEsperado.Email, clienteRetornado.Email);
        }

        [Fact]
        public async Task GetById_DeveRetornarBadRequestQuandoClienteNaoEncontrado()
        {
            
            int clienteId = 999; 
            var mockRepository = new Mock<IClienteRepository>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(repo => repo.GetClienteByIdAsync(clienteId)).ReturnsAsync((Cliente)null);

            var controlador = new ClienteController(mockRepository.Object, mockMapper.Object);
        
            var resultadoAcao = await controlador.GetById(clienteId);

            Assert.IsType<BadRequestObjectResult>(resultadoAcao);
            var resultadoBadRequest = resultadoAcao as BadRequestObjectResult;
            Assert.NotNull(resultadoBadRequest);
            Assert.Equal("Cliente nao encontrado", resultadoBadRequest.Value);
        }

        [Fact]
        public async Task Post_DeveRetornarBadRequestQuandoClienteNulo()
        {
            
            var mockRepository = new Mock<IClienteRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new ClienteController(mockRepository.Object, mockMapper.Object);
            
            var result = await controller.Post(null);
            
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarBadRequestQuandoEmailInvalido()
        {
            var clienteDto = new ClienteAdicionarDto { Email = "email_invalido" };
            var mockRepository = new Mock<IClienteRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new ClienteController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Post(clienteDto);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarOkQuandoClienteValido()
        {
            var clienteDto = new ClienteAdicionarDto { Email = "email_valido@example.com" };
            var mockRepository = new Mock<IClienteRepository>();
            mockRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);
            var mockMapper = new Mock<IMapper>();
            var controller = new ClienteController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Post(clienteDto);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarBadRequestQuandoIdInvalido()
        {
            
            var mockRepository = new Mock<IClienteRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new ClienteController(mockRepository.Object, mockMapper.Object);

            
            var result = await controller.Put(0, null);

            
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarBadRequestQuandoEmailInvalido()
        {
            
            int clienteId = 1;
            var clienteAtualizarDto = new ClienteAtualizarDto { Email = "email_invalido" };
            var clienteBanco = new Cliente { Id = clienteId, Email = "email_valido@example.com" };

            var mockRepository = new Mock<IClienteRepository>();
            mockRepository.Setup(repo => repo.GetClienteByIdAsync(clienteId)).ReturnsAsync(clienteBanco);

            var mockMapper = new Mock<IMapper>();
            var controller = new ClienteController(mockRepository.Object, mockMapper.Object);

            
            var result = await controller.Put(clienteId, clienteAtualizarDto);

            
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarOkQuandoClienteValido()
        {
            
            int clienteId = 1;
            var clienteAtualizarDto = new ClienteAtualizarDto { Email = "email_valido@example.com" };
            var clienteBanco = new Cliente { Id = clienteId, Email = "email_valido@example.com" };

            var mockRepository = new Mock<IClienteRepository>();
            mockRepository.Setup(repo => repo.GetClienteByIdAsync(clienteId)).ReturnsAsync(clienteBanco);
            mockRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);

            var mockMapper = new Mock<IMapper>();
            var controller = new ClienteController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Put(clienteId, clienteAtualizarDto);

            
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_DeveRetornarBadRequestQuandoIdInvalido()
        {
            
            var mockRepository = new Mock<IClienteRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new ClienteController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Delete(0);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_DeveRetornarNotFoundQuandoClienteNaoEncontrado()
        {
            int clienteId = 1;
            Cliente clienteExclusao = null;

            var mockRepository = new Mock<IClienteRepository>();
            mockRepository.Setup(repo => repo.GetClienteByIdAsync(clienteId)).ReturnsAsync(clienteExclusao);

            var mockMapper = new Mock<IMapper>();
            var controller = new ClienteController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Delete(clienteId);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Delete_DeveRetornarOkQuandoClienteDeletadoComSucesso()
        {
            int clienteId = 1;
            var clienteExclusao = new Cliente { Id = clienteId };

            var mockRepository = new Mock<IClienteRepository>();
            mockRepository.Setup(repo => repo.GetClienteByIdAsync(clienteId)).ReturnsAsync(clienteExclusao);
            mockRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);

            var mockMapper = new Mock<IMapper>();
            var controller = new ClienteController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Delete(clienteId);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}