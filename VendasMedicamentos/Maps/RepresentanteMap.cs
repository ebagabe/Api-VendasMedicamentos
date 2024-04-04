using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendasMedicamentos.Models.Entities;

namespace VendasMedicamentos.Maps
{
    public class RepresentanteMap : BaseMap<Representante>
    {
        public RepresentanteMap() : base("tb_representantes") { }

        public override void Configure(EntityTypeBuilder<Representante> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnName("data_nascimento");
        }
    }
}
