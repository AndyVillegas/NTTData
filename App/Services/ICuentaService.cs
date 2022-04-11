using App.Dtos.Cuentas;
using App.Models.Cuenta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public interface ICuentaService
    {
        Task<IEnumerable<CuentaViewModel>> Get();
        Task<CuentaFormViewModel> Get(int id);
        Task Create(CreateCuentaDto model);
        Task Update(int id, UpdateCuentaDto model);
        Task Delete(int id);
    }
}