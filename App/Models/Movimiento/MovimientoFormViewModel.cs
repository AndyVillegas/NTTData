using App.Common.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace App.Models.Movimiento
{
    public class MovimientoFormViewModel : MovimientoViewModel
    {
        [DisplayName("Tipo de movimiento")]
        public TipoMovimiento TipoMovimiento { get; set; }
        public IEnumerable<SelectListItem> Cuentas { get; set; }
        public IEnumerable<SelectListItem> TiposMovimiento { get; set; }
    }
}
