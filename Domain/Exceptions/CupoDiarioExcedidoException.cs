using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class CupoDiarioExcedidoException : ValidationException
    {
        public CupoDiarioExcedidoException() : base("Cupo diario excedido", Constants.CUPO_DIARIO_EXCEDIDO) {}
    }
}
