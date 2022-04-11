using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Cuenta : IEntityModel
    {
        public Cuenta()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public int Id { get; set; }
        public string NumeroCuenta { get; set; }
        public int TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal Saldo { get; set; }
        public int ClienteId { get; set; }
        public bool? Estado { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
