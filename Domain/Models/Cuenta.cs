using Domain.Common.Enums;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string NumeroCuenta { get; set; }
        public TipoCuenta TipoCuenta { get; set; }
        public string TipoCuentaDescripcion
        {
            get
            {
                return this.TipoCuenta.GetString();
            }
        }
        public decimal SaldoInicial { get; set; }
        public decimal Saldo { get; set; }
        public int ClienteId { get; set; }
        public string Cliente { get; set; }
        public bool? Estado { get; set; }
    }
}
