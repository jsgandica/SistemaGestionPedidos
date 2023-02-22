using Microsoft.AspNetCore.Mvc;
using Nikko.SistGestionPedido.Logic.Contracts;
using Nikko.SistGestionPedido.Models;
using Nikko.SistGestionPedido.UI.Models.ViewModels;

namespace Nikko.SistGestionPedido.UI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService= clienteService;
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
                                                             Telefono= c.Telefono,
                                                         }).ToList();


            return View(lstClienteViewModel);
        }
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {

            Cliente cliente = new Cliente()
            {

                Nombre = clienteViewModel.Nombre,
                Fecha = clienteViewModel.Fecha,
                Telefono= clienteViewModel.Telefono,
            };
            if (ModelState.IsValid)
            {

                bool respuesta = await _clienteService.Insertar(cliente);
                return RedirectToAction("Index", "Cliente");

            }


            return View();
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
                Telefono=_cliente.Result.Telefono
            };
            return View(clienteViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, ClienteViewModel clienteViewModel)
        {

            bool respuesta = await _clienteService.Eliminar(id);
            return RedirectToAction("Index", "Cliente");

            return View();

        }


    }
}
