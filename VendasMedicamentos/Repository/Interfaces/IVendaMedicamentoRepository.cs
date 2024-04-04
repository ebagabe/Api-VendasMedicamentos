using VendasMedicamentos.Models.Dtos;
using VendasMedicamentos.Models.Entities;

namespace VendasMedicamentos.Repository.Interfaces
{
    public interface IVendaMedicamentoRepository : IBaseRepository
    {
        Task<IEnumerable<VendaMedicamentoDto>> GetVendasPorNomeClienteAsync(string nomeCliente);
    }
}
