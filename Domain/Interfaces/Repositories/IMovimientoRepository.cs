using Domain.Entities;
using Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IMovimientoRepository: IBaseRepository<Movimiento>
    {
        Task<IEnumerable<Movimiento>> GetAll(MovimientoQuery query);
        Task<IEnumerable<Movimiento>> GetAll(MovimientoRangoQuery query);
    }
}
