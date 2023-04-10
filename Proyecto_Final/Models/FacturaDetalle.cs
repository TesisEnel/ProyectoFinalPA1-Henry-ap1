using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Models
{
#nullable disable
    public class FacturaDetalle
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Id de la factura es requerido")]
        public int FacturaId { get; set; }
        [Required(ErrorMessage = "El Id del suplidor es requerido")]

        public int SuplidorId { get; set; }
        
        public int PagoId { get; set; }

        public string Descripcion { get; set; }

        public long MontoTotalFacturas { get; set; }

        public virtual Facturas facturas { get; set; }

        public Facturas factura { get; set; } = new Facturas();


        public FacturaDetalle()
        {
            Id = 0;
            FacturaId = 0;
            SuplidorId = 0;
            MontoTotalFacturas = 0;
            Descripcion = string.Empty;
        }

        public FacturaDetalle(int id, int suplidorId,  int cantidad, long montoTotalFacturas, string descripcion)
        {
            Id = id;
            SuplidorId = suplidorId;
            MontoTotalFacturas = montoTotalFacturas;
            Descripcion = descripcion;
        }


    }
}