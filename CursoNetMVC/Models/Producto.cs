using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CursoNetMVC.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [DisplayName("Nombre del producto")]
        [MaxLength(100)]
        public string Nombre { get; set; } = null!;
        [DisplayName("Resumen")]
        [MaxLength(200)]
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }

        public bool Activo { get; set; }
    }
}
