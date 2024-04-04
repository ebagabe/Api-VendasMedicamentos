namespace VendasMedicamentos.Models.Dtos
{
    public class MedicamentoAdicionarDto
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}
