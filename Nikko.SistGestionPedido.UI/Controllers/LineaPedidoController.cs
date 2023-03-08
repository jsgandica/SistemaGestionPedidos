using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nikko.SistGestionPedido.Logic.Contracts;
using Nikko.SistGestionPedido.Models;
using Nikko.SistGestionPedido.UI.Models.ViewModels;
using System.IO;
using Newtonsoft.Json;
using Nikko.SistGestionPedido.Logic.Service;
using System.Net.Http.Headers;


namespace Nikko.SistGestionPedido.UI.Controllers
{
    public class LineaPedidoController : Controller
    {
        HttpClient client;
        string url = "https://localhost:7097/api/Producto";
        private readonly IPedidoService _pedidoService;
        private readonly ILineaPedidoService _lineaPedidoService;
        public LineaPedidoController(IPedidoService pedidoService, ILineaPedidoService lineaPedidoService)
        {
            _pedidoService = pedidoService;
            _lineaPedidoService = lineaPedidoService;
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task <IActionResult> Index()
        {
            IQueryable<LineaPedido> queryLineaPedidoSQL = await _lineaPedidoService.ObtenerTodos();

            List<LineaPedidoViewModel> lstlineaPedidoViewModel = queryLineaPedidoSQL
                                                         .Select(c => new LineaPedidoViewModel()
                                                         {
                                                             Id = c.Id,
                                                             Cantidad=c.Cantidad,
                                                             PedidoId=c.PedidoId,
                                                             ProductoId=c.ProductoId
                                                         }).ToList();
            return View(lstlineaPedidoViewModel);
           
        }
        public async Task<IActionResult> Create()
        {
            IQueryable<Pedido> queryPedidoSQL = await _pedidoService.ObtenerTodos();
            List<PedidoViewModel> lstPedidoViewModel = queryPedidoSQL
                                                             .Select(c => new PedidoViewModel()
                                                             {
                                                                 Id = c.Id,
                                                                 CodigoFactura = c.CodigoFactura,
                                                             }).ToList();
            List<SelectListItem> itemsc = lstPedidoViewModel.ConvertAll(i =>
            {
                return new SelectListItem()
                {
                    Text = i.CodigoFactura.ToString(),
                    Value = i.Id.ToString(),
                    Selected = false
                };
            });
            //items.Add (new SelectListItem {Text ="Seleccione..",Value="0", Disabled=true, Selected=true });
            ViewBag.Items1 = itemsc;
            //*****************************************
            HttpResponseMessage _responseMessage = await client.GetAsync(url);
            if (_responseMessage.IsSuccessStatusCode)
            {
                var _responseData = _responseMessage.Content.ReadAsStringAsync().Result;

                 List <ProductoViewModel> Product = JsonConvert.DeserializeObject<List<ProductoViewModel>>(_responseData);
                List<SelectListItem> items = Product.ConvertAll(i =>
                {
                    return new SelectListItem()
                    {
                        Text = i.Nombre.ToString(),
                        Value = i.productoId.ToString(),
                        Selected = false
                    };
                });
                ViewBag.Items = items;
                
            }
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LineaPedidoViewModel lineapedidoViewModel)
        {
           
            LineaPedido lineaPedido = new LineaPedido()
            {
                Cantidad = lineapedidoViewModel.Cantidad                                
            };
            if (ModelState.IsValid)
            {

                bool respuesta = await _lineaPedidoService.Insertar(lineaPedido);
                return RedirectToAction("Index", "LineaPedido");

            }

            IQueryable<Pedido> queryPedidoSQL = await _pedidoService.ObtenerTodos();
            List<PedidoViewModel> lstPedidoViewModel = queryPedidoSQL
                                                             .Select(c => new PedidoViewModel()
                                                             {
                                                                 Id = c.Id,
                                                                 CodigoFactura = c.CodigoFactura,
                                                             }).ToList();
            List<SelectListItem> itemsc = lstPedidoViewModel.ConvertAll(i =>
            {
                return new SelectListItem()
                {
                    Text = i.CodigoFactura.ToString(),
                    Value = i.Id.ToString(),
                    Selected = false
                };
            });
            //items.Add (new SelectListItem {Text ="Seleccione..",Value="0", Disabled=true, Selected=true });
            ViewBag.Items1 = itemsc;
            //*****************************************

            HttpResponseMessage _responseMessage = await client.GetAsync(url);
            if (_responseMessage.IsSuccessStatusCode)
            {
                var _responseData = _responseMessage.Content.ReadAsStringAsync().Result;

                List<ProductoViewModel> Product = JsonConvert.DeserializeObject<List<ProductoViewModel>>(_responseData);
                List<SelectListItem> items = Product.ConvertAll(i =>
                {
                    return new SelectListItem()
                    {
                        Text = i.Nombre.ToString(),
                        Value = i.productoId.ToString(),
                        Selected = false
                    };
                });
                ViewBag.Items = items;

            }

            return View("Create");
        }
    }
}
