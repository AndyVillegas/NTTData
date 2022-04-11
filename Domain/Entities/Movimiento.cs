using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Movimiento : IEntityModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public int CuentaId { get; set; }
        public bool? Estado { get; set; }

        public virtual Cuenta Cuenta { get; set; }
    }
}
