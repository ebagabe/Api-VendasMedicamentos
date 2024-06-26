﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
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

            return cliente != null ? Ok(cliente) : BadRequest("Cliente nao encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteAdicionarDto cliente)
        {
            if (cliente == null) return BadRequest("Dados invalidos");

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(cliente.Email, emailPattern))
            {
                return BadRequest("O email fornecido não é válido.");
            }

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

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(clienteBanco.Email, emailPattern))
            {
                return BadRequest("O email fornecido não é válido.");
            }

            var clienteAtualizar = _mapper.Map(cliente, clienteBanco);

            _repository.Update(clienteAtualizar);

            return await _repository.SaveChangesAsync() 
                ? Ok("Cliente atualizado com sucesso") 
                : BadRequest("Erro ao atualizar um cliente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Cliente inválido");

            var clienteExclusao = await _repository.GetClienteByIdAsync(id);

            if (clienteExclusao == null) return NotFound("Cliente não encontrado");

            _repository.Delete(clienteExclusao);

            return await _repository.SaveChangesAsync()
                 ? Ok("Cliente deletado com sucesso")
                 : BadRequest("Erro ao deletar o cliente");
        }



    }
}
