using VendasMedicamentos.Context;
using VendasMedicamentos.Repository.Interfaces;

namespace VendasMedicamentos.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly VendasMedicamentosContext _context;
        public BaseRepository(VendasMedicamentosContext context) 
        { 
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
