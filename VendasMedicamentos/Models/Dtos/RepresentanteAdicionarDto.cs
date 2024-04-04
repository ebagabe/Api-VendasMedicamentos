namespace VendasMedicamentos.Models.Dtos
{
    public class RepresentanteAdicionarDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateOnly? DataNascimento { get; set; }
    }
}
