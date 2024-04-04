namespace VendasMedicamentos.Models.Entities
{
    public class Representante : Base
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
