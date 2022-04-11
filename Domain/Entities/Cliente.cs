using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Cliente : IEntityModel
    {
        public Cliente()
        {
            Cuenta = new HashSet<Cuenta>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contrasenia { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}
