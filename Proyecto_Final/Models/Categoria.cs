using System.ComponentModel.DataAnnotations;

#nullable disable
namespace Proyecto_Final.Models
{
   public  class Categoria
    {
         [Key]  
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. Seleccione una categoria")]
        public string Descripcion{ get; set; } // Nombre de la categoria
        public bool Estado { get; set; } = true;             


    }
}