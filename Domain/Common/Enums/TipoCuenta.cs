using System;

namespace Domain.Common.Enums
{
    public enum TipoCuenta
    {
        Ahorro = 1,
        Corriente
    }
    public static class TipoCuentaExtensions
    {
        public static string GetString(this TipoCuenta me)
        {
            return me switch
            {
                TipoCuenta.Ahorro => "Ahorro",
                TipoCuenta.Corriente => "Corriente",
                _ => throw new NotImplementedException(),
            };
        }
    }
}