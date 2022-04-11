using Domain.Models;
using Domain.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IReporteService
    {
        Task<IEnumerable<EstadoCuenta>> GetEstadoCuenta(MovimientoRangoQuery query);
    }
}
