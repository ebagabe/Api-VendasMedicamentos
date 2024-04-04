using Microsoft.EntityFrameworkCore;
using VendasMedicamentos.Context;
using VendasMedicamentos.Models.Dtos;
using VendasMedicamentos.Models.Entities;
using VendasMedicamentos.Repository.Interfaces;

namespace VendasMedicamentos.Repository
{
    public class VendaMedicamentoRepository : BaseRepository, IVendaMedicamentoRepository
    {
        private readonly VendasMedicamentosContext _context;

        public VendaMedicamentoRepository(VendasMedicamentosContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VendaMedicamentoDto>> GetVendasPorNomeClienteAsync(string nomeCliente)
        {
            return await _context.VendaMedicamentos
                .Where(v => v.Cliente.Nome.Contains(nomeCliente))
                .Select(v => new VendaMedicamentoDto
                {
                    Id = v.Id,
                    NomeRepresentante = v.Representante.Nome,
                    NomeCliente = v.Cliente.Nome,
                    NomeMedicamento = v.Medicamento.Nome,
                    Quantidade = v.Quantidade,
                    Valor = v.Medicamento.Valor
                })
                .ToListAsync();
                
        }

    }
}
