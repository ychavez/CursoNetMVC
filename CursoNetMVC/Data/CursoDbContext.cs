using CursoNetMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoNetMVC.Data
{
    public class CursoDbContext : DbContext
    {

        public CursoDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }
    }
}
