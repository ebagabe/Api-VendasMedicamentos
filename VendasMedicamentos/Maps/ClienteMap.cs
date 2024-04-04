using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendasMedicamentos.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace VendasMedicamentos.Maps
{
    public class ClienteMap : BaseMap<Cliente>
    {
        public ClienteMap() : base("tb_clientes") { }

        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Email).HasColumnName("email")
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder.Property(x => x.Telefone).HasColumnName("telefone").HasColumnType("varchar(20)").IsRequired(false);
        }
    }
}
