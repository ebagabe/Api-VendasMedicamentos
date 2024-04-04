using Microsoft.EntityFrameworkCore;
using VendasMedicamentos.Context;
using VendasMedicamentos.Models.Dtos;
using VendasMedicamentos.Models.Entities;
using VendasMedicamentos.Repository.Interfaces;

namespace VendasMedicamentos.Repository
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        private readonly VendasMedicamentosContext _context;
        public ClienteRepository(VendasMedicamentosContext context) : base(context)
        {
            _context = context;   
        }
        public async Task<IEnumerable<ClienteDto>> GetClientesAsync()
        {
            return await _context.Clientes
                .Select(x => new ClienteDto { Id = x.Id, Nome = x.Nome, Email = x.Email, Telefone = x.Telefone })
                .ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Clientes
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
