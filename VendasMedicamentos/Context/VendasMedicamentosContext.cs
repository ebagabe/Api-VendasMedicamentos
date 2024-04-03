using Microsoft.EntityFrameworkCore;

namespace VendasMedicamentos.Context
{
    public class VendasMedicamentosContext : DbContext
    {
        public VendasMedicamentosContext(DbContextOptions<VendasMedicamentosContext> options) : base(options){ }
    }
}
