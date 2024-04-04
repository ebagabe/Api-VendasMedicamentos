using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendasMedicamentos.Models.Entities;

namespace VendasMedicamentos.Maps
{
    public class VendaMap : BaseMap<Venda> 
    {
        public VendaMap() : base("tb_vendas") { }

        public override void Configure(EntityTypeBuilder<Venda> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.ClienteId).HasColumnName("id_cliente").IsRequired();
            builder.Property(x => x.MedicamentoId).HasColumnName("id_medicamento").IsRequired();
            builder.Property(x => x.RepresentanteId).HasColumnName("id_representante").IsRequired();

            builder.HasOne(x => x.Cliente).WithMany().HasForeignKey(x => x.ClienteId);
            builder.HasOne(x => x.Medicamento).WithMany().HasForeignKey(x => x.MedicamentoId);
            builder.HasOne(x => x.Representante).WithMany().HasForeignKey(x => x.RepresentanteId);
        }
    }
}
