using VendasMedicamentos.Models.Dtos;
using VendasMedicamentos.Models.Entities;

namespace VendasMedicamentos.Repository.Interfaces
{
    public interface IMedicamentoRepository : IBaseRepository
    {
        Task<IEnumerable<MedicamentoDto>> GetMedicamentosAsync();
        Task<Medicamento> GetMedicamentoByIdAsync(int id);
    }
}
