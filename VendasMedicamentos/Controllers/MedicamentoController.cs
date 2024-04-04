using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VendasMedicamentos.Models.Dtos;
using VendasMedicamentos.Models.Entities;
using VendasMedicamentos.Repository.Interfaces;

namespace VendasMedicamentos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicamentoController : ControllerBase
    {
        private readonly IMedicamentoRepository _repository;
        private readonly IMapper _mapper;

        public MedicamentoController(IMedicamentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var medicamentos = await _repository.GetMedicamentosAsync();

            return medicamentos.Any()
                ? Ok(medicamentos)
                : BadRequest("Nenhum medicamento encontrado");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var medicamento = await _repository.GetMedicamentoByIdAsync(id);
            var medicamentoRetorno = _mapper.Map<MedicamentoDetalheDto>(medicamento);

            return medicamentoRetorno != null ? Ok(medicamentoRetorno) : BadRequest("Medicamento nao encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(MedicamentoAdicionarDto medicamento)
        {
            if (medicamento == null) return BadRequest("Dados invalidos");

            var registrarMedicamento = _mapper.Map<Medicamento>(medicamento);

            _repository.Add(registrarMedicamento);

            return await _repository.SaveChangesAsync()
                ? Ok("Medicamento cadastrado")
                : BadRequest("Erro ao cadastrar medicamento");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MedicamentoAtualizarDto medicamento)
        {
            if (id <= 0) return BadRequest("Medicamento nao informado");

            var medicamentoBanco = await _repository.GetMedicamentoByIdAsync(id);

            if (medicamento.Valor == null || medicamento.Valor == 0) medicamento.Valor = medicamentoBanco.Valor;
            if (medicamento.QuantidadeEstoque == null || medicamento.QuantidadeEstoque == 0) medicamento.QuantidadeEstoque = medicamentoBanco.QuantidadeEstoque;

            var medicamentoAtualizar = _mapper.Map(medicamento, medicamentoBanco);

            _repository.Update(medicamentoAtualizar);

            return await _repository.SaveChangesAsync()
                ? Ok("Medicamento atualizado com sucesso")
                : BadRequest("Erro ao atualizar um medicamento");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Medicamento inválido");

            var medicamentoExclusao = await _repository.GetMedicamentoByIdAsync(id);

            if (medicamentoExclusao == null) return NotFound("Medicamento nao encontrado");

            _repository.Delete(medicamentoExclusao);

            return await _repository.SaveChangesAsync()
                ? Ok("Medicamento deletado com sucesso")
                : BadRequest("Erro ao deletar medicamento");

        }
    }
}
