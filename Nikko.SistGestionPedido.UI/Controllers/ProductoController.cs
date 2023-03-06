using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nikko.SistGestionPedido.UI.Models.ViewModels;
using System.Net.Http.Headers;

namespace Nikko.SistGestionPedido.UI.Controllers
{
    public class ProductoController : Controller
    {
        HttpClient client;
        string url = "https://localhost:7097/api/Producto";

        public ProductoController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: ProductoController
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage _responseMessage = await client.GetAsync(url);
            if(_responseMessage.IsSuccessStatusCode)
            {
                var _responseData = _responseMessage.Content.ReadAsStringAsync().Result;

                var Producto = JsonConvert.DeserializeObject<List<ProductoViewModel>>(_responseData);

                return View(Producto);
            }

            return View("Error");
        }

    }
}
