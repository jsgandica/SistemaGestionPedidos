using Nikko.SistGestionPedido.DAL.Contracts;
using Nikko.SistGestionPedido.DAL.DataContext;
using Nikko.SistGestionPedido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikko.SistGestionPedido.DAL.Repositories
{
    public  class ComentarioRepository : IGenericRepository<Comentario>
    {
        private readonly PruebaContext _dbContext;

        public ComentarioRepository(PruebaContext context)
        {
            _dbContext = context;
        }

        public  async Task<bool> Actualizar(Comentario entity)
        {
            _dbContext.Comentarios.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public  async Task<bool> Eliminar(int id)
        {
            Comentario comentario = _dbContext.Comentarios.First(c => c.Id == id);
            _dbContext.Comentarios.Remove(comentario);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Insertar(Comentario entity)
        {
            _dbContext.Comentarios.Add(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Comentario> Obtener(int id)
        {
            return await _dbContext.Comentarios.FindAsync(id);
        }

        public async Task<IQueryable<Comentario>> ObtenerTodos()
        {
            IQueryable<Comentario> queryComentarioSQL = _dbContext.Comentarios;
            return queryComentarioSQL;
        }
    }
}
