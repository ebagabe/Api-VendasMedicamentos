namespace VendasMedicamentos.Models.Entities
{
    public class Venda : Base
    {
        public Cliente Cliente { get; set; }
        public Medicamento Medicamento { get; set; }
        public Representante Representante { get; set; }
        public int ClienteId { get; set; }
        public int MedicamentoId { get; set; }
        public int RepresentanteId { get; set; }
    }
}
