using VendasMedicamentos.Models.Dtos;
using VendasMedicamentos.Models.Entities;

namespace VendasMedicamentos.Repository.Interfaces
{
    public interface IRepresentanteRepository : IBaseRepository
    {
        Task<IEnumerable<RepresentanteDto>> GetRepresentantesAsync();
        Task<Representante> GetRepresentanteByIdAsync(int id);
    }
}
