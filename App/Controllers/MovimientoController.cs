using App.Common;
using App.Common.Enums;
using App.Dtos.Movimientos;
using App.Exceptions;
using App.Models.Movimiento;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class MovimientoController : Controller
    {
        private readonly IMovimientoService _service;
        private readonly ICuentaService _cuentaService;
        public MovimientoController(IMovimientoService service,
            ICuentaService cuentaService)
        {
            _service = service;
            _cuentaService = cuentaService;
        }
        public async Task<IActionResult> Index()
        {
            var movimientos = await _service.Get();
            return View(movimientos);
        }

        // GET: MovimientoController/Create
        public async Task<IActionResult> Create()
        {
            var vm = new MovimientoFormViewModel();
            await PopulateViewModel(vm);
            return View(vm);
        }

        private async Task PopulateViewModel(MovimientoFormViewModel vm)
        {
            var cuentas = await _cuentaService.Get();
            vm.TiposMovimiento = new List<SelectListItem>
            {
                new SelectListItem(TipoMovimiento.Credito.GetString(), TipoMovimiento.Credito.ToString()),
                new SelectListItem(TipoMovimiento.Debito.GetString(), TipoMovimiento.Debito.ToString()),
            };
            vm.Cuentas = cuentas.Select(x => new SelectListItem
            {
                Text = $"{x.NumeroCuenta} - {x.Cliente}",
                Value = x.Id.ToString()
            });
        }

        // POST: MovimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] CreateMovimientoDto collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Create(collection);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (ValidationException validationException)
            {
                if (validationException.Code == Constants.SALDO_NO_DISPONIBLE ||
                    validationException.Code == Constants.CUPO_DIARIO_EXCEDIDO)
                    ModelState.AddModelError("Valor", validationException.Message);
                else
                    ModelState.AddModelError("", validationException.Message);
            }
            var vm = new MovimientoFormViewModel();
            await PopulateViewModel(vm);
            return View(vm);
        }
    }
}
