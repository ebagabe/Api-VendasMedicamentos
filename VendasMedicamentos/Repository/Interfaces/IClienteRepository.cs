using VendasMedicamentos.Models.Entities;

namespace VendasMedicamentos.Repository.Interfaces
{
    public interface IClienteRepository : IBaseRepository
    {
        IEnumerable<Cliente> GetClientes();
        Cliente GetClienteById(int id);
    }
}
