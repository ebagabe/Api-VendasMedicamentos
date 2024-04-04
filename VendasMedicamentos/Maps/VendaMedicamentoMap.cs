using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendasMedicamentos.Models.Entities;

namespace VendasMedicamentos.Maps
{
    public class VendaMedicamentoMap : BaseMap<VendaMedicamento>
    {
        public VendaMedicamentoMap() : base("tb_vendas_medicamentos") { }

        public override void Configure(EntityTypeBuilder<VendaMedicamento> builder)
        {
            base.Configure(builder);
            builder.Property(v => v.ClienteId).HasColumnName("cliente_id").IsRequired();
            builder.Property(v => v.MedicamentoId).HasColumnName("medicamento_id").IsRequired();
            builder.Property(v => v.RepresentanteId).HasColumnName("representante_id").IsRequired();
            builder.Property(v => v.Quantidade).HasColumnName("quantidade").IsRequired();

            builder.HasOne(v => v.Cliente)
                .WithMany()
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(v => v.Medicamento)
                .WithMany()
                .HasForeignKey(v => v.MedicamentoId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(v => v.Representante)
                .WithMany()
                .HasForeignKey(v => v.RepresentanteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
