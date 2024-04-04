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
        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Clientes.ToList();
        }

        public Cliente GetClienteById(int id)
        {
            return _context.Clientes.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
