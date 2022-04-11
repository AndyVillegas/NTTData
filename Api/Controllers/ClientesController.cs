using Domain.Dtos.Clientes;
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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClientesController(IClienteService service)
        {
            _service = service;
        }
        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _service.GetAll();
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<Cliente> Get(int id)
        {
            return await _service.Get(id);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<Cliente> Post([FromBody] CreateClienteDto cliente)
        {
            return await _service.Create(cliente);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UpdateClienteDto cliente)
        {
            await _service.Update(id, cliente);
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
