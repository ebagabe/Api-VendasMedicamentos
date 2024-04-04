using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendasMedicamentos.Models.Entities;

namespace VendasMedicamentos.Maps
{
    public class MedicamentoMap : BaseMap<Medicamento>
    {
        public MedicamentoMap() : base("tb_medicamentos") { }

        public override void Configure(EntityTypeBuilder<Medicamento> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Valor).HasPrecision(7, 2).HasColumnName("valor").IsRequired();
            builder.Property(x => x.QuantidadeEstoque).HasColumnName("quantidade_estoque");
        }
    }
}
