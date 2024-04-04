namespace VendasMedicamentos.Models.Dtos
{
    public class MedicamentoAtualizarDto
    {
        public string? Nome { get; set; }
        public decimal? Valor { get; set; }
        public int? QuantidadeEstoque { get; set; }
    }
}
