using System;
using System.ComponentModel;

namespace App.Models.Movimiento
{
    public class EstadoCuentaViewModel
    {
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public string Cliente { get; set; }
        public string Cuenta { get; set; }
        public int CuentaId { get; set; }
        [DisplayName("Tipo de cuenta")]
        public string TipoCuenta { get; set; }
        [DisplayName("Saldo inicial")]
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public decimal Movimiento { get; set; }
        [DisplayName("Saldo disponible")]
        public decimal SaldoDisponible { get; set; }
    }
}
