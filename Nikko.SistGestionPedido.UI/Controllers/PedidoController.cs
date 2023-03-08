using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nikko.SistGestionPedido.Logic.Contracts;
using Nikko.SistGestionPedido.Models;
using Nikko.SistGestionPedido.UI.Models.ViewModels;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;

namespace Nikko.SistGestionPedido.UI.Controllers
{
    public class PedidoController : Controller
    {
        
        private readonly IPedidoService _pedidoService;
        private readonly IClienteService _clienteService;
        private readonly IVendedorService _vendedorService;
                
        public PedidoController(IPedidoService pedidoService, IClienteService clienteService, IVendedorService vendedorService)
        {
            _pedidoService = pedidoService;
            _clienteService = clienteService;
            _vendedorService = vendedorService;
            
        }
        
        public async Task<IActionResult> Index(PedidoViewModel pedidoViewModel)
        {
            IQueryable<Pedido> queryPedidoSQL = await _pedidoService.ObtenerTodos();

            List<PedidoViewModel> lstPedidoViewModel = queryPedidoSQL
                                                         .Select(c => new PedidoViewModel()
                                                         {
                                                             Id = c.Id,
                                                             Fecha = c.Fecha,
                                                         }).ToList();
            return View(lstPedidoViewModel);
        }

        public async Task<IActionResult> Create()
        {
            IQueryable<Vendedor> queryVendedorSQL = await _vendedorService.ObtenerTodos();
            List<VendedorViewModel> lstVendedorViewModel = queryVendedorSQL
                                                             .Select(c => new VendedorViewModel()
                                                             {
                                                                 Id = c.Id,
                                                                 Nombre = c.Nombre,
                                                             }).ToList();
            List<SelectListItem> items = lstVendedorViewModel.ConvertAll(i =>
            {
                return new SelectListItem()
                {
                    Text = i.Nombre.ToString(),
                    Value = i.Id.ToString(),
                    Selected = false
                };
            });
            //items.Add (new SelectListItem {Text ="Seleccione..",Value="0", Disabled=true, Selected=true });
            ViewBag.Items = items;

            //************************

            IQueryable<Cliente> queryClienteSQL = await _clienteService.ObtenerTodos();
            List<ClienteViewModel> lstClienteViewModel = queryClienteSQL
                                                             .Select(c => new ClienteViewModel()
                                                             {
                                                                 Id = c.Id,
                                                                 Nombre = c.Nombre,
                                                             }).ToList();
            List<SelectListItem> itemsc = lstClienteViewModel.ConvertAll(i =>
            {
                return new SelectListItem()
                {
                    Text = i.Nombre.ToString(),
                    Value = i.Id.ToString(),
                    Selected = false
                };
            });
            //items.Add (new SelectListItem {Text ="Seleccione..",Value="0", Disabled=true, Selected=true });
            ViewBag.Items1 = itemsc;
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PedidoViewModel pedidoViewModel, int IdVendedor)
        {

            Pedido pedido = new Pedido()
            {
                Fecha = pedidoViewModel.Fecha,
                CodigoFactura = pedidoViewModel.CodigoFactura,
                Total = pedidoViewModel.Total,
                Estatus = pedidoViewModel.Estatus,
                VendedorId = IdVendedor,
                ClienteId = pedidoViewModel.ClienteId
            };
            if (ModelState.IsValid)
            {

                bool respuesta = await _pedidoService.Insertar(pedido);
                return RedirectToAction("Index", "Pedido");

            }

            IQueryable<Vendedor> queryVendedorSQL = await _vendedorService.ObtenerTodos();
            List<VendedorViewModel> lstVendedorViewModel = queryVendedorSQL
                                                             .Select(c => new VendedorViewModel()
                                                             {
                                                                 Id = c.Id,
                                                                 Nombre = c.Nombre,
                                                             }).ToList();
            List<SelectListItem> items = lstVendedorViewModel.ConvertAll(i =>
            {
                return new SelectListItem()
                {
                    Text = i.Nombre.ToString(),
                    Value = i.Id.ToString(),
                    Selected = false
                };
            });
            //items.Add (new SelectListItem {Text ="Seleccione..",Value="0", Disabled=true, Selected=true });
            ViewBag.Items = items;
            //***************************************
            //************************

            IQueryable<Cliente> queryClienteSQL = await _clienteService.ObtenerTodos();
            List<ClienteViewModel> lstClienteViewModel = queryClienteSQL
                                                             .Select(c => new ClienteViewModel()
                                                             {
                                                                 Id = c.Id,
                                                                 Nombre = c.Nombre,
                                                             }).ToList();
            List<SelectListItem> itemsc = lstClienteViewModel.ConvertAll(i =>
            {
                return new SelectListItem()
                {
                    Text = i.Nombre.ToString(),
                    Value = i.Id.ToString(),
                    Selected = false
                };
            });
            //items.Add (new SelectListItem {Text ="Seleccione..",Value="0", Disabled=true, Selected=true });
            ViewBag.Items1 = itemsc;

            return View("Create");
        }
        public async Task<IActionResult> Edit(int id)
        {
            Task<Pedido> _pedido = _pedidoService.Obtener(id);
            PedidoViewModel pedidoViewModel = new PedidoViewModel()
            {
                Id = _pedido.Result.Id,
                Fecha = _pedido.Result.Fecha,
                CodigoFactura = _pedido.Result.CodigoFactura,
                Total = _pedido.Result.Total,
                Estatus= _pedido.Result.Estatus
            };
            return View(pedidoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PedidoViewModel pedidoViewModel)
        {

            Pedido pedido = new Pedido()
            {
                Id = pedidoViewModel.Id,
                Fecha = pedidoViewModel.Fecha,
                CodigoFactura = pedidoViewModel.CodigoFactura,
                Total = pedidoViewModel.Total,
                Estatus= pedidoViewModel.Estatus

            };
            if (ModelState.IsValid)
            {
                bool respuesta = await _pedidoService.Actualizar(pedido);
                return RedirectToAction("Index", "Pedido");
            }
            return View();
        }
    }
}
