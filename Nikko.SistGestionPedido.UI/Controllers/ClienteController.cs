using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nikko.SistGestionPedido.Logic.Contracts;
using Nikko.SistGestionPedido.Models;
using Nikko.SistGestionPedido.UI.Models.ViewModels;

namespace Nikko.SistGestionPedido.UI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IVendedorService _vendedorService;
        public ClienteController(IClienteService clienteService, IVendedorService vendedorService)
        {
            _clienteService = clienteService;
            _vendedorService = vendedorService;
        }
        public async Task<IActionResult> PrimerCliente(ClienteViewModel clienteViewModel)
        {
            IQueryable<Cliente> queryClienteSQL = await _clienteService.ObtenerTodos();

            List<ClienteViewModel> lstClienteViewModel = queryClienteSQL
                                                         .Select(c => new ClienteViewModel()
                                                         {
                                                             Id = c.Id,
                                                             Nombre = c.Nombre,
                                                             Fecha = c.Fecha,
                                                             Telefono = c.Telefono,
                                                         }).ToList();
            var primerCliente = (from j in lstClienteViewModel
                                orderby j.Id ascending
                                select j).FirstOrDefault();
            ClienteViewModel clienteViewModel1 = new ClienteViewModel()
            {
                Id= primerCliente.Id,
                Nombre= primerCliente.Nombre,
                Fecha= primerCliente.Fecha,
                Telefono= primerCliente.Telefono
            };
            return View(clienteViewModel1);
        }
        public async Task<IActionResult> Index(ClienteViewModel clienteViewModel)
        {
            IQueryable<Cliente> queryClienteSQL = await _clienteService.ObtenerTodos();

            List<ClienteViewModel> lstClienteViewModel = queryClienteSQL
                                                         .Select(c => new ClienteViewModel()
                                                         {
                                                             Id = c.Id,
                                                             Nombre = c.Nombre,
                                                             Fecha = c.Fecha,
                                                             Telefono = c.Telefono,
                                                         }).ToList();


            return View(lstClienteViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            Task<Cliente> _cliente = _clienteService.Obtener(id);
            ClienteViewModel clienteViewModel = new ClienteViewModel()
            {
                Id = _cliente.Result.Id,
                Nombre = _cliente.Result.Nombre,
                Telefono = _cliente.Result.Telefono,
                Fecha = _cliente.Result.Fecha

            };
            return View(clienteViewModel);
        }
        public async Task<IActionResult> Create()
        {
            //IQueryable<Vendedor> queryVendedorSQL = await _vendedorService.ObtenerTodos();
            //List<VendedorViewModel> lstVendedorViewModel = queryVendedorSQL
            //                                                 .Select(c => new VendedorViewModel()
            //                                                 {
            //                                                     Id = c.Id,
            //                                                     Nombre = c.Nombre,
            //                                                 }).ToList();
            //List<SelectListItem> items = lstVendedorViewModel.ConvertAll(i =>
            //{
            //    return new SelectListItem()
            //    {
            //        Text = i.Nombre.ToString(),
            //        Value = i.Id.ToString(),
            //        Selected = false
            //    };
            //});
            ////items.Add (new SelectListItem {Text ="Seleccione..",Value="0", Disabled=true, Selected=true });
            //ViewBag.Items = items;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {

            Cliente cliente = new Cliente()
            {

                Nombre = clienteViewModel.Nombre,
                Fecha = clienteViewModel.Fecha,
                Telefono = clienteViewModel.Telefono,
                //VendedorId = IdVendedor
            };
            if (ModelState.IsValid)
            {

                bool respuesta = await _clienteService.Insertar(cliente);
                return RedirectToAction("Index", "Cliente");

            }
            
            //IQueryable<Vendedor> queryVendedorSQL = await _vendedorService.ObtenerTodos();
            //List<VendedorViewModel> lstVendedorViewModel = queryVendedorSQL
            //                                                 .Select(c => new VendedorViewModel()
            //                                                 {
            //                                                     Id = c.Id,
            //                                                     Nombre = c.Nombre,
            //                                                 }).ToList();
            //List<SelectListItem> items = lstVendedorViewModel.ConvertAll(i =>
            //{
            //    return new SelectListItem()
            //    {
            //        Text = i.Nombre.ToString(),
            //        Value = i.Id.ToString(),
            //        Selected = false
            //    };
            //});
            //items.Add (new SelectListItem {Text ="Seleccione..",Value="0", Disabled=true, Selected=true });
            //ViewBag.Items = items;

            return View("Create");
        }
        public async Task<IActionResult> Edit(int id)
        {
            Task<Cliente> _cliente = _clienteService.Obtener(id);
            ClienteViewModel clienteViewModel = new ClienteViewModel()
            {
                Id = _cliente.Result.Id,
                Nombre = _cliente.Result.Nombre,
                Telefono = _cliente.Result.Telefono,
                Fecha = _cliente.Result.Fecha

            };
            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClienteViewModel clienteViewModel)
        {

            Cliente cliente = new Cliente()
            {
                Id = clienteViewModel.Id,
                Nombre = clienteViewModel.Nombre,
                Telefono = clienteViewModel.Telefono,
                Fecha = clienteViewModel.Fecha

            };
            if (ModelState.IsValid)
            {
                bool respuesta = await _clienteService.Actualizar(cliente);
                return RedirectToAction("Index", "Cliente");
            }
            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {

            Task<Cliente> _cliente = _clienteService.Obtener(id);
            ClienteViewModel clienteViewModel = new ClienteViewModel()
            {

                Id = _cliente.Result.Id,
                Nombre = _cliente.Result.Nombre,
                Fecha = _cliente.Result.Fecha,
                Telefono = _cliente.Result.Telefono
            };
            return View(clienteViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ClienteViewModel clienteViewModel)
        {

            bool respuesta = await _clienteService.Eliminar(id);
            return RedirectToAction("Index", "Cliente");

            return View();

        }


    }
}
