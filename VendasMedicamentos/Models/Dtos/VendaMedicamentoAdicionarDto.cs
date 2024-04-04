namespace VendasMedicamentos.Models.Dtos
{
    public class VendaMedicamentoAdicionarDto
    {
        public int ClienteId { get; set; }
        public int RepresentanteId { get; set; }
        public int MedicamentoId { get; set; }
        public int Quantidade { get; set; }
    }
}
