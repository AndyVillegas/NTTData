using App.Dtos.Movimientos;
using App.Models.Movimiento;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public interface IMovimientoService
    {
        Task<IEnumerable<MovimientoViewModel>> Get();
        Task Create(CreateMovimientoDto movimiento);
    }
}