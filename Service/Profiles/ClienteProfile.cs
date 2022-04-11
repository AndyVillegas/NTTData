using AutoMapper;
using Domain.Dtos.Clientes;
using Domain.Entities;

namespace Service.Profiles
{
    public class ClienteProfile: Profile
    {
        public ClienteProfile()
        {
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<UpdateClienteDto, Cliente>();
            CreateMap<Cliente, Domain.Models.Cliente>();
        }
    }
}
