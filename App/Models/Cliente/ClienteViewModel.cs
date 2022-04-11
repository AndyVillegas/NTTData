using System.ComponentModel;

namespace App.Models.Cliente
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        [DisplayName("Identificación")]
        public string Identificacion { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        [DisplayName("Contraseña")]
        public string Contrasenia { get; set; }
    }
}
