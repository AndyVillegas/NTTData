using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IReporteService _service;
        public ReportesController(IReporteService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<EstadoCuenta>> GetEstadoCuenta([FromQuery] MovimientoRangoQuery query)
        {
            return await _service.GetEstadoCuenta(query);
        }
    }
}
