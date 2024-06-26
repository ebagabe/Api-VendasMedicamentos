﻿using AutoMapper;
using VendasMedicamentos.Models.Dtos;
using VendasMedicamentos.Models.Entities;

namespace VendasMedicamentos.Helpers
{
    public class VendasMedicamentosProfile : Profile
    {
        public VendasMedicamentosProfile()
        {
            CreateMap<Cliente, ClienteDetalheDto>();

            CreateMap<ClienteAdicionarDto, Cliente>();
            CreateMap<ClienteAtualizarDto, Cliente>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Representante, RepresentanteDetalheDto>();
            CreateMap<RepresentanteAdicionarDto, Representante>();
            CreateMap<RepresentanteAtualizarDto, Representante>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Medicamento, MedicamentoDetalheDto>();
            CreateMap<MedicamentoAdicionarDto,  Medicamento>();
            CreateMap<MedicamentoAtualizarDto,  Medicamento>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember, destMember) => srcMember != null));

            CreateMap<VendaMedicamento, VendaMedicamentoDto>()
                .ForMember(dest => dest.NomeCliente, opt => opt.MapFrom(src => src.Cliente.Nome));

            CreateMap<VendaMedicamentoAdicionarDto, VendaMedicamento>();

           
        }
    }
}
