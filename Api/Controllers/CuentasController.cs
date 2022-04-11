using Domain.Dtos.Cuentas;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentaService _service;
        public CuentasController(ICuentaService service)
        {
            _service = service;
        }
        // GET: api/<CuentasController>
        [HttpGet]
        public async Task<IEnumerable<Cuenta>> Get()
        {
            return await _service.GetAll();
        }

        // GET api/<CuentasController>/5
        [HttpGet("{id}")]
        public async Task<Cuenta> Get(int id)
        {
            return await _service.Get(id);
        }

        // POST api/<CuentasController>
        [HttpPost]
        public async Task<Cuenta> Post([FromBody] CreateCuentaDto Cuenta)
        {
            return await _service.Create(Cuenta);
        }

        // PUT api/<CuentasController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UpdateCuentaDto Cuenta)
        {
            await _service.Update(id, Cuenta);
        }

        // DELETE api/<CuentasController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
