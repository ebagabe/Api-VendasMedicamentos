using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasMedicamentos.Controllers;
using VendasMedicamentos.Models.Dtos;
using VendasMedicamentos.Models.Entities;
using VendasMedicamentos.Repository.Interfaces;

namespace Api.Tests
{
    public class MedicamentoControllerTests
    {
        [Fact]
        public async Task Get_DeveRetornarOkQuandoExistemMedicamentos()
        {
            var mockRepository = new Mock<IMedicamentoRepository>();
            var mockMapper = new Mock<IMapper>();

            var medicamentosEsperados = new List<MedicamentoDto>() { new MedicamentoDto(), new MedicamentoDto() };
            mockRepository.Setup(repo => repo.GetMedicamentosAsync()).ReturnsAsync(medicamentosEsperados);

            var controller = new MedicamentoController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Get();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<MedicamentoDto>>(okResult.Value);
            Assert.Equal(medicamentosEsperados.Count, model.Count());
        }

        [Fact]
        public async Task Get_DeveRetornarBadRequestQuandoNaoExistemMedicamentos()
        {
            var mockRepository = new Mock<IMedicamentoRepository>();
            var mockMapper = new Mock<IMapper>();

            var medicamentosEsperados = new List<MedicamentoDto>();
            mockRepository.Setup(repo => repo.GetMedicamentosAsync()).ReturnsAsync(medicamentosEsperados);

            var controller = new MedicamentoController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Get();

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetById_DeveRetornarOkQuandoMedicamentoEncontrado()
        {
            int medicamentoId = 1;
            var mockRepository = new Mock<IMedicamentoRepository>();
            var mockMapper = new Mock<IMapper>();

            var medicamentoEsperado = new MedicamentoDetalheDto();
            mockRepository.Setup(repo => repo.GetMedicamentoByIdAsync(medicamentoId)).ReturnsAsync(new Medicamento());
            mockMapper.Setup(mapper => mapper.Map<MedicamentoDetalheDto>(It.IsAny<Medicamento>())).Returns(medicamentoEsperado);

            var controller = new MedicamentoController(mockRepository.Object, mockMapper.Object);

            var result = await controller.GetById(medicamentoId);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetById_DeveRetornarBadRequestQuandoMedicamentoNaoEncontrado()
        {

            int medicamentoId = 1;
            var mockRepository = new Mock<IMedicamentoRepository>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(repo => repo.GetMedicamentoByIdAsync(medicamentoId)).ReturnsAsync((Medicamento)null);

            var controller = new MedicamentoController(mockRepository.Object, mockMapper.Object);

            var result = await controller.GetById(medicamentoId);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarOkQuandoMedicamentoCadastrado()
        {
            var mockRepository = new Mock<IMedicamentoRepository>();
            var mockMapper = new Mock<IMapper>();

            var medicamentoDto = new MedicamentoAdicionarDto
            {
                Nome = "Nome do Medicamento",
                Valor = 10,
                QuantidadeEstoque = 10
            };

            mockRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);

            var controller = new MedicamentoController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Post(medicamentoDto);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarBadRequestQuandoDadosInvalidos()
        {
            var mockRepository = new Mock<IMedicamentoRepository>();
            var mockMapper = new Mock<IMapper>();

            var controller = new MedicamentoController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Post(null);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarOkQuandoMedicamentoAtualizado()
        {

            int medicamentoId = 1;
            var mockRepository = new Mock<IMedicamentoRepository>();
            var mockMapper = new Mock<IMapper>();

            var medicamentoDto = new MedicamentoAtualizarDto();
            var medicamento = new Medicamento();
            mockRepository.Setup(repo => repo.GetMedicamentoByIdAsync(medicamentoId)).ReturnsAsync(medicamento);
            mockRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);

            var controller = new MedicamentoController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Put(medicamentoId, medicamentoDto);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarBadRequestQuandoIdMedicamentoInvalido()
        {
            var mockRepository = new Mock<IMedicamentoRepository>();
            var mockMapper = new Mock<IMapper>();

            var controller = new MedicamentoController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Put(0, new MedicamentoAtualizarDto());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_DeveRetornarOkQuandoMedicamentoDeletado()
        {
            int medicamentoId = 1;
            var mockRepository = new Mock<IMedicamentoRepository>();
            var mockMapper = new Mock<IMapper>();

            var medicamento = new Medicamento();
            mockRepository.Setup(repo => repo.GetMedicamentoByIdAsync(medicamentoId)).ReturnsAsync(medicamento);
            mockRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);

            var controller = new MedicamentoController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Delete(medicamentoId);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_DeveRetornarNotFoundQuandoMedicamentoNaoEncontrado()
        {
            int medicamentoId = 1;
            var mockRepository = new Mock<IMedicamentoRepository>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(repo => repo.GetMedicamentoByIdAsync(medicamentoId)).ReturnsAsync((Medicamento)null);

            var controller = new MedicamentoController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Delete(medicamentoId);
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
