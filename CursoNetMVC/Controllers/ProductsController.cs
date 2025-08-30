using CursoNetMVC.Data;
using CursoNetMVC.Models;
using CursoNetMVC.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;

namespace CursoNetMVC.Controllers
{
   
    public class ProductsController : Controller
    {
        private readonly CursoDbContext dbContext;
        private readonly IMemoryCache cache;

        public ProductsController(CursoDbContext dbContext, 
            IMemoryCache cache)
        {
            this.dbContext = dbContext;
            this.cache = cache;
        }
        // Get todos los productos para una tabla

    
        public async Task<IActionResult> Index(int? pagina)
        {

            //var productos = dbContext.Productos
            //    .Include(x=> x.Categoria)
            //    .ThenInclude(x=> x.SubCategoria)
            //    .ToList();

            string cacheKey = "ListaProductos";

            if (!cache.TryGetValue(cacheKey, out List<Producto>? Productos))
            {

                Productos = dbContext
                    .Productos
                    .AsNoTracking()
                    .Where(x => x.Activo).ToList();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(1))
                    .SetPriority(CacheItemPriority.Normal);

                cache.Set(cacheKey, Productos, cacheOptions);

            }


            return View(Productos.Skip((pagina ?? 0)  * 3 ).Take(3).ToList());


        }


        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id is null)
                return NotFound();

            var product = await dbContext.Productos
                .AsNoTracking().FirstOrDefaultAsync(x=> x.Id == Id);

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
