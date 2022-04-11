using Domain.Dtos.Clientes;
using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IClienteService: IBaseService
        <Cliente, CreateClienteDto, UpdateClienteDto>
    {
    }
}
