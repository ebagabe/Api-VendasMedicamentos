using VendasMedicamentos.Models.Entities;

namespace VendasMedicamentos.Repository.Interfaces
{
    public interface IClienteRepository : IBaseRepository
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
    }
}
