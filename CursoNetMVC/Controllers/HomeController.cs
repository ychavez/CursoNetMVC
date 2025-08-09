using System.Diagnostics;
using CursoNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoNetMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet("Saludo")]
        public IActionResult Saludo()
        {
            SaludoModel saludo = new() { Nombre = "Juan Perez", Mensaje = "Saludos" };
            return View(saludo);
        }

        [HttpPost("SaludoRegreso")]
        public IActionResult SaludoRegreso(SaludoModel saludo)
        {
            if (ModelState.IsValid)
            {
                return View("Saludo", saludo);
            }
            return View("Saludo", saludo);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
