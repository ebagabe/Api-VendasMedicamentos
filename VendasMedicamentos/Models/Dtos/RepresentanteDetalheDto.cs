namespace VendasMedicamentos.Models.Dtos
{
    public class RepresentanteDetalheDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateOnly? DataNascimento { get; set; }
    }
}
