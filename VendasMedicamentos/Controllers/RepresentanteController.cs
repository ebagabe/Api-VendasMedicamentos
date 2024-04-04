using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using VendasMedicamentos.Models.Dtos;
using VendasMedicamentos.Models.Entities;
using VendasMedicamentos.Repository.Interfaces;

namespace VendasMedicamentos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepresentanteController : ControllerBase
    {
        private readonly IRepresentanteRepository _repository;
        private readonly IMapper _mapper;
        public RepresentanteController(IRepresentanteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var representantes = await _repository.GetRepresentantesAsync();

            return representantes.Any()
                ? Ok(representantes)
                : BadRequest("Nenhum representante encontrado");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var representante = await _repository.GetRepresentanteByIdAsync(id);
            var representanteRetorno = _mapper.Map<RepresentanteDetalheDto>(representante);

            return representanteRetorno != null ? Ok(representanteRetorno) : BadRequest("Representante nao encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(RepresentanteAdicionarDto representante)
        {
            if (representante == null) return BadRequest("Dados invalidos");

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(representante.Email, emailPattern))
            {
                return BadRequest("O email fornecido não é válido.");
            }

            var registrarRepresentante = _mapper.Map<Representante>(representante);

            _repository.Add(registrarRepresentante);

            return await _repository.SaveChangesAsync()
                ? Ok("Representante registrado com sucesso")
                : BadRequest("Erro ao cadastrar representante");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, RepresentanteAtualizarDto representante)
        {
            if (id <= 0) return BadRequest("Representante nao informado");

            var representanteBanco = await _repository.GetRepresentanteByIdAsync(id);

            var representanteAtualizar = _mapper.Map(representante, representanteBanco);

            _repository.Update(representanteAtualizar);

            return await _repository.SaveChangesAsync()
                ? Ok("Representante atualizado com sucesso")
                : BadRequest("Erro ao atualizar um representante");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Representante invalido");

            var representanteExclusao = await _repository.GetRepresentanteByIdAsync(id);

            if (representanteExclusao == null) return NotFound("Representante não encontrado");

            _repository.Delete(representanteExclusao);

            return await _repository.SaveChangesAsync()
                 ? Ok("Representante deletado com sucesso")
                 : BadRequest("Erro ao deletar o representante");
        }
    }
}
