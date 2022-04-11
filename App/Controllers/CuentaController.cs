using App.Common.Enums;
using App.Dtos.Cuentas;
using App.Models.Cuenta;
using App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class CuentaController : Controller
    {
        private readonly ICuentaService _service;
        private readonly IClienteService _clienteService;
        public CuentaController(ICuentaService service, IClienteService clienteService)
        {
            _service = service;
            _clienteService = clienteService;
        }
        // GET: CuentaController
        public async Task<IActionResult> Index()
        {
            var cuentas = await _service.Get();
            return View(cuentas);
        }

        // GET: CuentaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var model = await _service.Get(id);
            return View(model);
        }

        // GET: CuentaController/Create
        public async Task<IActionResult> Create()
        {
            var vm = new CuentaFormViewModel();
            await PoblarSelects(vm);
            return View(vm);
        }

        // POST: CuentaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] CreateCuentaDto collection)
        {
            try
            {
                await _service.Create(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CuentaController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _service.Get(id);
            await PoblarSelects(vm);
            return View(vm);
        }

        // POST: CuentaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateCuentaDto collection)
        {
            try
            {
                await _service.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CuentaController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _service.Get(id);
            return View(model);
        }

        // POST: CuentaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _service.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task PoblarSelects(CuentaFormViewModel vm)
        {
            var clientes = await _clienteService.Get();
            vm.Clientes = clientes.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Id.ToString()
            });
            vm.TiposCuenta = new List<SelectListItem>
            {
                new SelectListItem(TipoCuenta.Ahorro.GetString(), TipoCuenta.Ahorro.ToString()),
                new SelectListItem(TipoCuenta.Corriente.GetString(), TipoCuenta.Corriente.ToString()),
            };
        }
    }
}
