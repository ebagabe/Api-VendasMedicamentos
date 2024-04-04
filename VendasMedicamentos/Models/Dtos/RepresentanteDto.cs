namespace VendasMedicamentos.Models.Dtos
{
    public class RepresentanteDto
    {
        public int IdRepresentante { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
