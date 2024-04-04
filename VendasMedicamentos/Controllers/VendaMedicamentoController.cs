using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VendasMedicamentos.Models.Dtos;
using VendasMedicamentos.Models.Entities;
using VendasMedicamentos.Repository;
using VendasMedicamentos.Repository.Interfaces;

namespace VendasMedicamentos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaMedicamentoController : ControllerBase
    {
        private readonly IVendaMedicamentoRepository _repository;
        private readonly IMedicamentoRepository _medicamentoRepository;
        private readonly IMapper _mapper;
        public VendaMedicamentoController(IVendaMedicamentoRepository repository, IMapper mapper, IMedicamentoRepository medicamentoRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _medicamentoRepository = medicamentoRepository;
        }

        [HttpGet("cliente/{nomeCliente}")]
        public async Task<IActionResult> Get(string nomeCliente)
        {
            var vendas = await _repository.GetVendasPorNomeClienteAsync(nomeCliente);
            var vendasDto = _mapper.Map<IEnumerable<VendaMedicamentoDto>>(vendas);

            return vendasDto.Any()
                ? Ok(vendasDto)
                : BadRequest("Nenhuma venda registrada por esse cliente");
        }

        [HttpPost]
        public async Task<IActionResult> Post(VendaMedicamentoAdicionarDto venda)
        {
            if (venda == null ) return BadRequest("Dados invalidos");

            var vendaMedicamento = _mapper.Map<VendaMedicamento>(venda);
            var medicamento = await _medicamentoRepository.GetMedicamentoByIdAsync(venda.MedicamentoId);

            if(medicamento.QuantidadeEstoque < vendaMedicamento.Quantidade)
            {
                return BadRequest("Quantidade insuficiente em estoque.");
            }

            medicamento.QuantidadeEstoque -= venda.Quantidade;

            _repository.Add(vendaMedicamento);
            return await _repository.SaveChangesAsync() 
                ? Ok("Venda registrada com sucesso")
                : BadRequest("Venda nao registrada");
        }
    }
}
