using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CursoNetMVC.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [DisplayName("Nombre del producto")]
        [MaxLength(100)]
        public string Nombre { get; set; } = null!;

        public SubCategoria SubCategoria { get; set; }
  
    }


    public class SubCategoria {

        public int Id { get; set; }
        [DisplayName("Nombre del producto")]
        [MaxLength(100)]
        public string Nombre { get; set; } = null!;
    }
}
