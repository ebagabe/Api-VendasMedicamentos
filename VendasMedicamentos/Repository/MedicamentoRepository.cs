using Microsoft.EntityFrameworkCore;
using VendasMedicamentos.Context;
using VendasMedicamentos.Models.Dtos;
using VendasMedicamentos.Models.Entities;
using VendasMedicamentos.Repository.Interfaces;

namespace VendasMedicamentos.Repository
{
    public class MedicamentoRepository : BaseRepository, IMedicamentoRepository
    {
        private readonly VendasMedicamentosContext _context;
        public MedicamentoRepository(VendasMedicamentosContext context) : base(context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<MedicamentoDto>> GetMedicamentosAsync()
        {
            return await _context.Medicamentos
                .Select(x => new MedicamentoDto { Id = x.Id, Nome = x.Nome, Valor = x.Valor, QuantidadeEstoque = x.QuantidadeEstoque })
                .ToListAsync();
        }

        public async Task<Medicamento> GetMedicamentoByIdAsync(int id)
        {
            return await _context.Medicamentos
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
