using Microsoft.AspNetCore.Mvc;
using Nikko.SistGestionPedido.Logic.Contracts;
using Nikko.SistGestionPedido.Logic.Service;
using Nikko.SistGestionPedido.Models;
using Nikko.SistGestionPedido.UI.Models.ViewModels;

namespace Nikko.SistGestionPedido.UI.Controllers
{
    public class VendedorController : Controller
    {
        private readonly IVendedorService _vendedorService;
        public VendedorController(IVendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }
        public async Task<IActionResult> Index(VendedorViewModel vendedorViewModel)
        {
            IQueryable<Vendedor> queryClienteSQL = await _vendedorService.ObtenerTodos();

            List<VendedorViewModel> lstVendedorViewModel = queryClienteSQL
                                                         .Select(c => new VendedorViewModel()
                                                         {
                                                             Id = c.Id,
                                                             Nombre = c.Nombre,
                                                             Rowguid = c.Rowguid,
                                                         }).ToList();


            return View(lstVendedorViewModel);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VendedorViewModel vendedorViewModel)
        {

            Vendedor vendedor = new Vendedor()
            {

                Nombre = vendedorViewModel.Nombre,
                Rowguid = vendedorViewModel.Rowguid,

            };
            if (ModelState.IsValid)
            {

                bool respuesta = await _vendedorService.Insertar(vendedor);
                return RedirectToAction("Index", "Vendedor");

            }


            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            Task<Vendedor> _vendedor = _vendedorService.Obtener(id);
            VendedorViewModel vendedorViewModel = new VendedorViewModel()
            {
                Id = _vendedor.Result.Id,
                Nombre = _vendedor.Result.Nombre,
                Rowguid = _vendedor.Result.Rowguid

            };
            return View(vendedorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VendedorViewModel vendedorViewModel)
        {

            Vendedor vendedor = new Vendedor()
            {
                Id = vendedorViewModel.Id,
                Nombre = vendedorViewModel.Nombre,
                Rowguid = vendedorViewModel.Rowguid
                

            };
            if (ModelState.IsValid)
            {
                bool respuesta = await _vendedorService.Actualizar(vendedor);
                return RedirectToAction("Index", "Vendedor");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {

            Task<Vendedor> _vendedor = _vendedorService.Obtener(id);
            VendedorViewModel vendedorViewModel = new VendedorViewModel()
            {

                Id = _vendedor.Result.Id,
                Nombre = _vendedor.Result.Nombre,
                Rowguid = _vendedor.Result.Rowguid
                
            };
            return View(vendedorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id,VendedorViewModel vendedorViewModel)
        {

            bool respuesta = await _vendedorService.Eliminar(id);
            return RedirectToAction("Index", "Vendedor");

            return View();

        }
    }
}
