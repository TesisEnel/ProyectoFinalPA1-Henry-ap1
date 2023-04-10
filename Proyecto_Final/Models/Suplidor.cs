using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Models
{
#nullable disable
    public class Suplidor
    {
        [Key]
        public int SuplidorId { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre.")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "Campo email es requerido.")]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Formato inválido. name@gmail.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese un numero teléfonico.")]
        [RegularExpression(@"^\d{3}[- ]?\d{3}[- ]?\d{4}$", ErrorMessage = "Formato inválido. 000-000-0000")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre.")]

        public string NombreVendedor { get; set; }
        [Required(ErrorMessage = "Ingrese un numero teléfonico.")]

        [RegularExpression(@"^\d{3}[- ]?\d{3}[- ]?\d{4}$", ErrorMessage = "Formato inválido. 000-000-0000")]

        public string TelefonoVendedor { get; set; }
        [Required(ErrorMessage = "Ingrese una dirección.")]

        public string Direccion { get; set; }
        [DataType(DataType.Date)]

        public DateTime Fecha { get; set; }

        public bool Estado { get; set; } = true;
        public int UsuarioId { get; set; }

        public Suplidor()
        {
            SuplidorId = 0;
            UsuarioId = 0;
            Nombre = string.Empty;
            Email = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            Fecha = DateTime.Now;
        }


    }
}