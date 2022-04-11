using Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Movimientos
{
    public class CreateMovimientoDto
    {
        public TipoMovimiento TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public int CuentaId { get; set; }
    }
}
