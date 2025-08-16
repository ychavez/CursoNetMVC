using CursoNetMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CursoNetMVC.Data
{
    public class CursoDbContext : IdentityDbContext
    {

        public CursoDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }
    }
}
