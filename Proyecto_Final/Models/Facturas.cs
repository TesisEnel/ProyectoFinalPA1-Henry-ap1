using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final.Models
{   
  #nullable disable
  public  class Facturas
    {    [Key]
        public int FacturaId { get; set; }
        
        public int SuplidorId { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre del proveedor.")]

        public string NombreProvedor { get; set; }
        [Required(ErrorMessage = "Ingrese el numero de la factura.")]

        public string CodigoFactura { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Ingrese un Monto.")]

        public long MontoTotal { get; set; }

        public bool Estado { get; set; }=true;

        public int CategoriaId { get; set; }

        public int UsuarioId { get; set; }

         [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }


        [ForeignKey("SuplidorId")]
        public virtual Suplidor Suplidor { get; set; }

        public Facturas()
        {  
          FacturaId=0;
          SuplidorId=0;
          CategoriaId=0;
          NombreProvedor = string.Empty;
          FechaCreacion = DateTime.Now;
          Fecha=DateTime.Now;
          MontoTotal=0;
          
        }



    }
}