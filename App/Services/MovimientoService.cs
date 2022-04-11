using App.Dtos.Movimientos;
using App.Models.Movimiento;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public class MovimientoService : BaseService, IMovimientoService
    {
        private readonly string url = "Movimientos";
        public MovimientoService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Create(CreateMovimientoDto movimiento)
        {
            await PostAsync(url, movimiento);
        }

        public Task<IEnumerable<MovimientoViewModel>> Get()
        {
            return GetAsync<IEnumerable<MovimientoViewModel>>(url);
        }
    }
}
