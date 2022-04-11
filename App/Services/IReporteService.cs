using App.Models.Movimiento;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public interface IReporteService
    {
        Task<IEnumerable<EstadoCuentaViewModel>> GetEstadoCuenta(int clienteId, DateTime fechaInicio, DateTime fechaFin);
    }
}