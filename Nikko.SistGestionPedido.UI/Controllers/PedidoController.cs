using Microsoft.AspNetCore.Mvc;

namespace Nikko.SistGestionPedido.UI.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
