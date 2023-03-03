using Microsoft.AspNetCore.Mvc;
using Nikko.SistGestionPedido.UI.Models;
using System.Diagnostics;

namespace Nikko.SistGestionPedido.UI.Controllers
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

        public async Task<IActionResult> Inicio()
        {
            string dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            ViewBag.items = dateTime;
            int h = 110;
            string h1 = Convert.ToString(h);
            ViewBag.items1 = " "; ViewBag.items2 = " ";
                                            
            return View();
        }
        public async Task<IActionResult> Click_Despues()
        {
            string dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            ViewBag.items = dateTime;
            int h = 110;
            string h1 = Convert.ToString(h);
            ViewBag.items1 = "Hola "; ViewBag.items2 = " ";

            return View();
        }
        public async Task<IActionResult> Click_Antes()
        {
            string dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            ViewBag.items = dateTime;
            int h = 110;
            string h1 = Convert.ToString(h);
            ViewBag.items1 = " "; ViewBag.items2 = "Hola";

            return View();
        }

        public async Task<IActionResult> Click_Reemplazar()
        {
            string dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            ViewBag.items = dateTime;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}