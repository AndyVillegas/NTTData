using App.Dtos.Clientes;
using App.Models.Cliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteViewModel>> Get();
        Task<ClienteViewModel> Get(int id);
        Task Create(CreateClienteDto model);
        Task Update(int id, UpdateClienteDto model);
        Task Delete(int id);
    }
}