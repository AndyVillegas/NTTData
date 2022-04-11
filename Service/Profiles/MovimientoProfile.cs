using AutoMapper;
using Domain.Common.Enums;
using Domain.Dtos.Movimientos;
using Domain.Entities;

namespace Service.Profiles
{
    public class MovimientoProfile : Profile
    {
        public MovimientoProfile()
        {
            CreateMap<CreateMovimientoDto, Movimiento>();
            CreateMap<UpdateMovimientoDto, Movimiento>();
            CreateMap<Movimiento, Domain.Models.Movimiento>()
                .ForMember(dest => dest.Cuenta, opts => opts.MapFrom(src => src.Cuenta.NumeroCuenta));
            CreateMap<Movimiento, Domain.Models.EstadoCuenta>()
                .ForMember(dest => dest.Cuenta, opts => opts.MapFrom(src => src.Cuenta.NumeroCuenta))
                .ForMember(dest => dest.TipoCuenta, opts => opts.MapFrom(src => ((TipoCuenta)src.Cuenta.TipoCuenta).GetString()))
                .ForMember(dest => dest.Cliente, opts => opts.MapFrom(src => src.Cuenta.Cliente.Nombre));
        }
    }
}
