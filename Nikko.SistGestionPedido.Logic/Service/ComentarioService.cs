using Nikko.SistGestionPedido.DAL.Contracts;
using Nikko.SistGestionPedido.Logic.Contracts;
using Nikko.SistGestionPedido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikko.SistGestionPedido.Logic.Service
{
    public class ComentarioService: IComentarioService
    {
        private readonly IGenericRepository<Comentario> _comentarioService;

        public ComentarioService(IGenericRepository<Comentario> comentarioService)
        {
            _comentarioService = comentarioService;
        }

        public  async Task<bool> Actualizar(Comentario comentario)
        {
            return await _comentarioService.Actualizar(comentario);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _comentarioService.Eliminar(id);
        }

        public async Task<bool> Insertar(Comentario comentario)
        {
            return await _comentarioService.Insertar(comentario);
        }

        public async Task<Comentario> Obtener(int id)
        {
            return await _comentarioService.Obtener(id);
        }

        public async  Task<IQueryable<Comentario>> ObtenerTodos()
        {
            return await _comentarioService.ObtenerTodos();
        }

        
    }
}
