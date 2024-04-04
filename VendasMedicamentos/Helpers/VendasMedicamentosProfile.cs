using AutoMapper;
using VendasMedicamentos.Models.Dtos;
using VendasMedicamentos.Models.Entities;

namespace VendasMedicamentos.Helpers
{
    public class VendasMedicamentosProfile : Profile
    {
        public VendasMedicamentosProfile()
        {
            CreateMap<Cliente, ClienteDetalheDto>();
        }
    }
}
