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
    public class RepresentanteControllerTests
    {
        [Fact]
        public async Task Get_DeveRetornarOkQuandoRepresentantesEncontrados()
        {
            // Arrange
            var mockRepository = new Mock<IRepresentanteRepository>();
            var mockMapper = new Mock<IMapper>();

            var representantes = new List<RepresentanteDto>() { new RepresentanteDto() };
            mockRepository.Setup(repo => repo.GetRepresentantesAsync()).ReturnsAsync(representantes);

            var controller = new RepresentanteController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Get();

            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            var representantesRetornados = okResult.Value as IEnumerable<RepresentanteDto>;
            Assert.Equal(representantes, representantesRetornados);
        }

        [Fact]
        public async Task Post_DeveRetornarOkQuandoRepresentanteCadastrado()
        {
            var mockRepository = new Mock<IRepresentanteRepository>();
            var mockMapper = new Mock<IMapper>();

            var representanteDto = new RepresentanteAdicionarDto
            {
                Email = "email@exemplo.com"
            };

            mockRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);

            var controller = new RepresentanteController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Post(representanteDto);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_DeveRetornarOkQuandoRepresentanteDeletado()
        {
            int representanteId = 1;
            var mockRepository = new Mock<IRepresentanteRepository>();
            var mockMapper = new Mock<IMapper>();

            var representanteExclusao = new Representante { Id = representanteId };
            mockRepository.Setup(repo => repo.GetRepresentanteByIdAsync(representanteId)).ReturnsAsync(representanteExclusao);
            mockRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);

            var controller = new RepresentanteController(mockRepository.Object, mockMapper.Object);

            var result = await controller.Delete(representanteId);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
