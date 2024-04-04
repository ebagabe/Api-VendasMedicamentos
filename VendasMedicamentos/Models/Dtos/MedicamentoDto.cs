namespace VendasMedicamentos.Models.Dtos
{
    public class MedicamentoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int? QuantidadeEstoque { get; set; }
    }
}
