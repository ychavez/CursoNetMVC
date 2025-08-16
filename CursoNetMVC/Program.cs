using CursoNetMVC.Data;
using CursoNetMVC.Tools;
using Microsoft.EntityFrameworkCore;

namespace CursoNetMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IMatematicas, Matematicas>();
            builder.Services.AddDbContext<CursoDbContext>
                (x => x.UseSqlServer(builder.Configuration
                .GetConnectionString("CursoContextConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Products}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
