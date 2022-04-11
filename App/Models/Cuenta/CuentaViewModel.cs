using App.Common.Enums;
using System.ComponentModel;

namespace App.Models.Cuenta
{
    public class CuentaViewModel
    {
        public int Id { get; set; }
        [DisplayName("Número de cuenta")]
        public string NumeroCuenta { get; set; }
        public TipoCuenta TipoCuenta { get; set; }
        [DisplayName("Tipo de cuenta")]
        public string TipoCuentaDescripcion { get; set; }
        [DisplayName("Saldo inicial")]
        public decimal SaldoInicial { get; set; }
        public decimal Saldo { get; set; }
        public int ClienteId { get; set; }
        public string Cliente { get; set; }
        public bool? Estado { get; set; }
    }
}
