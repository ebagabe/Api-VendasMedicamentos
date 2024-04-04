using Microsoft.EntityFrameworkCore;
using VendasMedicamentos.Context;
using VendasMedicamentos.Models.Dtos;
using VendasMedicamentos.Models.Entities;
using VendasMedicamentos.Repository.Interfaces;

namespace VendasMedicamentos.Repository
{
    public class RepresentanteRepository : BaseRepository, IRepresentanteRepository
    {
        private readonly VendasMedicamentosContext _context;
        public RepresentanteRepository(VendasMedicamentosContext context) : base(context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<RepresentanteDto>> GetRepresentantesAsync()
        {
            return await _context.Representantes
                .Select(x => new RepresentanteDto { Id = x.Id, Nome = x.Nome, Email = x.Email, DataNascimento = x.DataNascimento })
                .ToListAsync();
        }

        public async Task<Representante> GetRepresentanteByIdAsync(int id)
        {
            return await _context.Representantes
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
