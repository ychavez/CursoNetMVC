using System.ComponentModel;

namespace CursoNetMVC.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [DisplayName("Nombre del producto")]
        public string Nombre { get; set; } = null!;
        [DisplayName("Resumen")]
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
    }
}
