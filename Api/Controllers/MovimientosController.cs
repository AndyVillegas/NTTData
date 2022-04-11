using Domain.Dtos.Movimientos;
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
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientoService _service;
        public MovimientosController(IMovimientoService service)
        {
            _service = service;
        }
        // GET: api/<MovimientosController>
        [HttpGet]
        public async Task<IEnumerable<Movimiento>> Get()
        {
            return await _service.GetAll();
        }

        // GET api/<MovimientosController>/5
        [HttpGet("{id}")]
        public async Task<Movimiento> Get(int id)
        {
            return await _service.Get(id);
        }

        // POST api/<MovimientosController>
        [HttpPost]
        public async Task<Movimiento> Post([FromBody] CreateMovimientoDto Movimiento)
        {
            return await _service.Create(Movimiento);
        }

        // PUT api/<MovimientosController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UpdateMovimientoDto Movimiento)
        {
            await _service.Update(id, Movimiento);
        }

        // DELETE api/<MovimientosController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
