using CursoNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoNetMVC.Controllers
{
    public class ProductsController : Controller
    {
        static List<Producto> productos;
        public ProductsController()
        {
            productos = new()
            {
                new Producto { Id = 1, Nombre = "Laptop", Descripcion = "Portátil de 15 pulgadas", Precio = 1200.99m },
                new Producto { Id = 2, Nombre = "Smartphone", Descripcion = "Teléfono inteligente Android", Precio = 699.50m },
                new Producto { Id = 3, Nombre = "Auriculares", Descripcion = "Auriculares inalámbricos", Precio = 150.00m }
            };
        }
        // Get todos los productos para una tabla
        public async Task<IActionResult> Index()
        {
            return View(productos);
        }

        public async Task<IActionResult> Create()
        {
            return View(new Producto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            productos.Add(producto);
            return View();
        }



    }
}
