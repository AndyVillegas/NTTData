using System;
using System.ComponentModel;
using System.Globalization;

namespace App.Models.Movimiento
{
    public class MovimientoViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        [DisplayName("Cuenta")]
        public int CuentaId { get; set; }
        public string Cuenta { get; set; }
        public bool? Estado { get; set; }
        public string Descripcion
        {
            get
            {
                var template = Valor > 0 ? "Depósito de" : "Retiro de";
                return $"{template} {Math.Abs(Valor).ToString("C", CultureInfo.CreateSpecificCulture("en-US"))}";
            }
        }
    }
}
