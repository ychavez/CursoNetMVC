using CursoNetMVC.Data;
using CursoNetMVC.Models;
using CursoNetMVC.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoNetMVC.Controllers
{
   
    public class ProductsController : Controller
    {
        private readonly CursoDbContext dbContext;

        public ProductsController(CursoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // Get todos los productos para una tabla

    
        public async Task<IActionResult> Index()
        {

            //var productos = dbContext.Productos
            //    .Include(x=> x.Categoria)
            //    .ThenInclude(x=> x.SubCategoria)
            //    .ToList();


            return View(dbContext.Productos.Where(x => x.Activo).ToList());
        }


        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id is null)
                return NotFound();

            var product = await dbContext.Productos.FindAsync(Id);

            if (product is null)
                return NotFound();

            return View(product);
        }


        [HttpPost] 
        public async Task<IActionResult> Edit(int Id, Producto producto) 
        {
            if (Id != producto.Id)
                return NotFound();

            dbContext.Update(producto);
            await dbContext.SaveChangesAsync();

            return View(producto);
        
        }


        public async Task<IActionResult> Create()
        {
            return View(new Producto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {


            dbContext.Productos.Add(producto);

            await dbContext.SaveChangesAsync();

            return View();
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id) 
        {

            if (id is null)
                return NotFound();

            var product = await dbContext.Productos.FirstOrDefaultAsync(x => x.Id == id);



            if (product is null)
                return NotFound();

            return View(product);      
        }


        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id) 
        {
            var product = await dbContext.Productos.FindAsync(id);
            if (product is not null)
            {
                dbContext.Productos.Remove(product);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        
        }
    }
}
