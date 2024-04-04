using Microsoft.EntityFrameworkCore;
using VendasMedicamentos.Models.Entities;

namespace VendasMedicamentos.Context
{
    public class VendasMedicamentosContext : DbContext
    {

        public VendasMedicamentosContext(DbContextOptions<VendasMedicamentosContext> options) : base(options){ }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Representante> Representantes { get; set; }
        public DbSet<Medicamento>  Medicamentos { get; set;}
        public DbSet<VendaMedicamento> VendaMedicamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
