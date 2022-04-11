using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Queries;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovimientoRepository : BaseRepository<Movimiento>, IMovimientoRepository
    {
        private readonly NTTDATAContext _context;
        public MovimientoRepository(NTTDATAContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movimiento>> GetAll(MovimientoQuery query)
        {
            var movimientos = _context.Movimientos.AsQueryable();
            movimientos.Where(e => e.CuentaId == query.CuentaId &&
            e.Fecha.Date.Equals(query.Fecha.Date));
            return await movimientos.ToListAsync();
        }

        public async Task<IEnumerable<Movimiento>> GetAll(MovimientoRangoQuery query)
        {
            var movimientos = _context.Movimientos
                .Include(e => e.Cuenta)   
                .ThenInclude(e => e.Cliente)
                .Where(e => e.Cuenta.ClienteId == query.ClienteId &&
                e.Fecha.Date >= query.FechaInicio.Date && e.Fecha.Date <= query.FechaFin.Date);
            return await movimientos.ToListAsync();
        }

        protected override IQueryable<Movimiento> GetQueryable()
        {
            return base.GetQueryable()
                .Include(e => e.Cuenta);
        }
    }
}
