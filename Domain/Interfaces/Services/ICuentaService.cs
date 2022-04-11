using Domain.Dtos.Cuentas;
using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface ICuentaService: IBaseService
        <Cuenta, CreateCuentaDto, UpdateCuentaDto>
    {
    }
}
