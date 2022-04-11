using AutoMapper;
using Domain.Dtos.Cuentas;
using Domain.Entities;

namespace Service.Profiles
{
    public class CuentaProfile : Profile
    {
        public CuentaProfile()
        {
            CreateMap<CreateCuentaDto, Cuenta>();
            CreateMap<UpdateCuentaDto, Cuenta>();
            CreateMap<Cuenta, Domain.Models.Cuenta>()
                .ForMember(dest => dest.Cliente, opts => opts.MapFrom(src => src.Cliente.Nombre));
        }
    }
}
