using Domain.Dtos.Movimientos;
using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IMovimientoService: IBaseService
        <Movimiento, CreateMovimientoDto, UpdateMovimientoDto>
    {
    }
}
