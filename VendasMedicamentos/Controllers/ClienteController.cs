using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VendasMedicamentos.Models.Dtos;
using VendasMedicamentos.Models.Entities;
using VendasMedicamentos.Repository.Interfaces;

namespace VendasMedicamentos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        public ClienteController(IClienteRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientes = await _repository.GetClientesAsync();

            return clientes.Any()
                ? Ok(clientes)
                : BadRequest("Nenhum cliente encontrado");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _repository.GetClienteByIdAsync(id);
            var clienteRetorno = _mapper.Map<ClienteDetalheDto>(cliente);

            return clienteRetorno != null ? Ok(clienteRetorno) : BadRequest("Cliente nao encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteAdicionarDto cliente)
        {
            if (cliente == null) return BadRequest("Dados invalidos");

            var registrarCliente = _mapper.Map<Cliente>(cliente);

            _repository.Add(registrarCliente);

            return await _repository.SaveChangesAsync() 
                ? Ok("Paciente registrado com sucesso") 
                : BadRequest("Erro ao cadastrar paciente");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClienteAtualizarDto cliente)
        {
            if (id <= 0) return BadRequest("Usuario nao informado");

            var clienteBanco = await _repository.GetClienteByIdAsync(id);

            var clienteAtualizar = _mapper.Map(cliente, clienteBanco);

            _repository.Update(clienteAtualizar);

            return await _repository.SaveChangesAsync() 
                ? Ok("Cliente atualizado com sucesso") 
                : BadRequest("Erro ao atualizar um cliente");
        }



    }
}
