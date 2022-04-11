using App.Models;
using App.Models.Movimiento;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IReporteService _reporteService;
        public HomeController(IClienteService clienteService,
            IReporteService reporteService)
        {
            _clienteService = clienteService;
            _reporteService = reporteService;
        }

        public async Task<IActionResult> Index(int? clienteId, DateTime? fechaInicio, DateTime? fechaFin)
        {
            IEnumerable<EstadoCuentaViewModel> estadosCuenta = new List<EstadoCuentaViewModel>();
            if (clienteId.HasValue && fechaInicio.HasValue && fechaFin.HasValue)
            {
                estadosCuenta = await _reporteService.GetEstadoCuenta(clienteId.Value, fechaInicio.Value, fechaFin.Value);
            }
            var clientes = await _clienteService.Get();
            ViewBag.Clientes = clientes.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Id.ToString(),
                Selected = clienteId.HasValue && x.Id == clienteId.Value
            });
            ViewBag.ClienteId = clienteId;
            ViewBag.FechaInicio = fechaInicio;
            ViewBag.FechaFin = fechaFin;
            return View(estadosCuenta);
        }
    }
}
