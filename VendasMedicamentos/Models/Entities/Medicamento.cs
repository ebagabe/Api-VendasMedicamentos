namespace VendasMedicamentos.Models.Entities
{
    public class Medicamento : Base
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int? QuantidadeEstoque { get; set; }
    }
}
