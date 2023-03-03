using Microsoft.AspNetCore.Mvc;
using Nikko.SistGestionPedido.Logic.Contracts;
using Nikko.SistGestionPedido.Logic.Service;
using Nikko.SistGestionPedido.Models;
using Nikko.SistGestionPedido.UI.Models.ViewModels;

namespace Nikko.SistGestionPedido.UI.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly IComentarioService _comentarioService;
        public ComentarioController(IComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }
        
        public async Task<IActionResult> Index(ComentarioViewModel comentarioViewModel)
        {
            IQueryable<Comentario> queryComentarioSQL = await _comentarioService.ObtenerTodos();

            List<ComentarioViewModel> lstComentarioViewModel = queryComentarioSQL
                                                         .Select(c => new ComentarioViewModel()
                                                         {
                                                             Id = c.Id,
                                                             Comentario1 = c.Comentario1,
                                                             Fecha = c.Fecha,
                                                             
                                                         }).ToList();

            return View(lstComentarioViewModel);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ComentarioViewModel comentarioViewModel)
        {

            Comentario comentario = new Comentario()
            {

                Comentario1 = comentarioViewModel.Comentario1,
                Fecha = comentarioViewModel.Fecha,
                Id = comentarioViewModel.Id,
            };
            if (ModelState.IsValid)
            {

                bool respuesta = await _comentarioService.Insertar(comentario);
                return RedirectToAction("Index", "Comentario");

            }


            return View();
        }


        public async Task<IActionResult> Edit(int id)
        {
            Task<Comentario> _comentario = _comentarioService.Obtener(id);
            ComentarioViewModel comentarioViewModel = new ComentarioViewModel()
            {
                Id = _comentario.Result.Id,
                Comentario1 = _comentario.Result.Comentario1,
                Fecha = _comentario.Result.Fecha,
                

            };
            return View(comentarioViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ComentarioViewModel comentarioViewModel)
        {

            Comentario comentario = new Comentario()
            {
                Id = comentarioViewModel.Id,
                Comentario1 = comentarioViewModel.Comentario1,
                Fecha = comentarioViewModel.Fecha,
                

            };
            if (ModelState.IsValid)
            {
                bool respuesta = await _comentarioService.Actualizar(comentario);
                return RedirectToAction("Index", "Comentario");
            }
            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {

            Task<Comentario> _comentario = _comentarioService.Obtener(id);
            ComentarioViewModel comentarioViewModel = new ComentarioViewModel()
            {

                Id = _comentario.Result.Id,
                Comentario1= _comentario.Result.Comentario1,
                Fecha = _comentario.Result.Fecha
            };
            return View(comentarioViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, ComentarioViewModel comentarioViewModel)
        {

            bool respuesta = await _comentarioService.Eliminar(id);
            return RedirectToAction("Index", "Comentario");

            return View();

        }

    }
}
