using App.Models.Movimiento;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public class ReporteService : BaseService, IReporteService
    {
        private readonly string url = "Reportes";
        public ReporteService(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<IEnumerable<EstadoCuentaViewModel>> GetEstadoCuenta(int clienteId, DateTime fechaInicio, DateTime fechaFin)
        {
            var queryUrl = $"{url}?clienteId={clienteId}&fechaInicio={fechaInicio:yyyy-MM-dd}&fechaFin={fechaFin:yyyy-MM-dd}";
            return await GetAsync<IEnumerable<EstadoCuentaViewModel>>(queryUrl);
        }
    }
}
