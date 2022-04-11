using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public class Movimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public int CuentaId { get; set; }
        public string Cuenta { get; set; }
        public bool? Estado { get; set; }
    }
}
