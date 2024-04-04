using Microsoft.AspNetCore.Mvc;
using VendasMedicamentos.Repository.Interfaces;

namespace VendasMedicamentos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repository;
        public ClienteController(IClienteRepository repository) 
        {
            _repository = repository;
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

            return cliente != null ? Ok(cliente) : BadRequest("Cliente não encontrado");
        }
    }
}
