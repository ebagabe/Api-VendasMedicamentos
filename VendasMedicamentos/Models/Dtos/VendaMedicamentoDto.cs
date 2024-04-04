namespace VendasMedicamentos.Models.Dtos
{
    public class VendaMedicamentoDto
    {
        public int Id { get; set; }
        public string NomeRepresentante { get; set; }
        public string NomeCliente { get; set; }
        public string NomeMedicamento { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
