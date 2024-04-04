using Microsoft.EntityFrameworkCore;
using VendasMedicamentos.Context;
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
        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _context.Clientes
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
