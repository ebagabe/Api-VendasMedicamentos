namespace VendasMedicamentos.Models.Entities
{
    public class VendaMedicamento : Base
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int MedicamentoId { get; set; }
        public Medicamento Medicamento { get; set; }
        public int RepresentanteId { get; set; }
        public Representante Representante { get; set; }
        public int Quantidade { get; set; }
    }
}
