using VendasMedicamentos.Models.Dtos;
using VendasMedicamentos.Models.Entities;

namespace VendasMedicamentos.Repository.Interfaces
{
    public interface IClienteRepository : IBaseRepository
    {
        Task<IEnumerable<ClienteDto>> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
    }
}
