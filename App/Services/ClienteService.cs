using App.Dtos.Clientes;
using App.Models.Cliente;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly string url = "Clientes";
        public ClienteService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Create(CreateClienteDto model)
        {
            await PostAsync(url, model);
        }

        public async Task Delete(int id)
        {
            await DeleteAsync($"{url}/{id}");
        }

        public Task<IEnumerable<ClienteViewModel>> Get()
        {
            return GetAsync<IEnumerable<ClienteViewModel>>(url);
        }

        public Task<ClienteViewModel> Get(int id)
        {
            return GetAsync<ClienteViewModel>($"{url}/{id}");
        }

        public async Task Update(int id, UpdateClienteDto model)
        {
            await PutAsync($"{url}/{id}", model);
        }
    }
}
