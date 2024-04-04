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
        public IActionResult Get()
        {
            var clientes = _repository.GetClientes();
            return clientes.Any()
                ? Ok(clientes)
                : BadRequest("Nenhum cliente encontrado");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _repository.GetClienteById(id);

            return cliente != null ? Ok(cliente) : BadRequest("Cliente não encontrado");
        }
    }
}
