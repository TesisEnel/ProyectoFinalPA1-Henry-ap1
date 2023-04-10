using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

#nullable disable // Para quitar el aviso de nulls

namespace Proyecto_Final.Models
{
    public class Pago // Entidad Pago
    {
        [Key]
        public int PagoId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. Seleccione un metodo de pago")]
        public string Metodo { get; set; } // Metodo de pago       
    
        public DateTime Fecha { get; set; }
        public int SuplidorId { get; set; }

        public int FacturaId { get; set; }

        public int MontoTotales { get; set; }
        public bool Estado { get; set; } = true;
        

    }
}