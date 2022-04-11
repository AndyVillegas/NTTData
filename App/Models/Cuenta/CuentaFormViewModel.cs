using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace App.Models.Cuenta
{
    public class CuentaFormViewModel : CuentaViewModel
    {
        public IEnumerable<SelectListItem> TiposCuenta { get; set; }
        public IEnumerable<SelectListItem> Clientes { get; set; }
    }
}
