using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class SaldoNoDisponibleException: ValidationException
    {
        public SaldoNoDisponibleException(): base("Saldo no disponible", Constants.SALDO_NO_DISPONIBLE){}
    }
}
