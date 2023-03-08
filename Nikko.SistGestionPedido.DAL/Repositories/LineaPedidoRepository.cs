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
    public class LineaPedidoRepository : IGenericRepository<LineaPedido>
    {
        private readonly PedidosContext _dbContext;

        public LineaPedidoRepository(PedidosContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> Actualizar(LineaPedido entity)
        {
            _dbContext.LineaPedidos.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            LineaPedido lineapedido = _dbContext.LineaPedidos.First(c => c.Id == id);
            _dbContext.LineaPedidos.Remove(lineapedido);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(LineaPedido entity)
        {
            _dbContext.LineaPedidos.Add(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<LineaPedido> Obtener(int id)
        {
            return await _dbContext.LineaPedidos.FindAsync(id);
        }

        public async Task<IQueryable<LineaPedido>> ObtenerTodos()
        {
            IQueryable<LineaPedido> queryLineaPedidoSQL = _dbContext.LineaPedidos;
            return queryLineaPedidoSQL;
        }
    }
}
