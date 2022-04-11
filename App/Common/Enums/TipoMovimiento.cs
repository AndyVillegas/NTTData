using System;

namespace App.Common.Enums
{
    public enum TipoMovimiento
    {
        Credito = 1,
        Debito
    }
    public static class TipoMovimientoExtensions
    {
        public static string GetString(this TipoMovimiento me)
        {
            return me switch
            {
                TipoMovimiento.Credito => "Crédito",
                TipoMovimiento.Debito => "Débito",
                _ => throw new NotImplementedException(),
            };
        }
    }
}
