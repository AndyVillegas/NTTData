using App.Dtos.Cuentas;
using App.Models.Cuenta;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public class CuentaService : BaseService, ICuentaService
    {
        private readonly string url = "Cuentas";
        public CuentaService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Create(CreateCuentaDto model)
        {
            await PostAsync(url, model);
        }

        public async Task Delete(int id)
        {
            await DeleteAsync($"{url}/{id}");
        }

        public Task<IEnumerable<CuentaViewModel>> Get()
        {
            return GetAsync<IEnumerable<CuentaViewModel>>(url);
        }

        public Task<CuentaFormViewModel> Get(int id)
        {
            return GetAsync<CuentaFormViewModel>($"{url}/{id}");
        }

        public async Task Update(int id, UpdateCuentaDto model)
        {
            await PutAsync($"{url}/{id}", model);
        }
    }
}
