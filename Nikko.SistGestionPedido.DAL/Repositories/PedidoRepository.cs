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
    public class PedidoRepository:IGenericRepository<Pedido>
    {
        private readonly PedidosContext _dbContext;

        public PedidoRepository(PedidosContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> Actualizar(Pedido entity)
        {
            _dbContext.Pedidos.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Pedido pedido = _dbContext.Pedidos.First(c => c.Id == id);
            _dbContext.Pedidos.Remove(pedido);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Pedido entity)
        {
            _dbContext.Pedidos.Add(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Pedido> Obtener(int id)
        {
            return await _dbContext.Pedidos.FindAsync(id);
        }

        public async Task<IQueryable<Pedido>> ObtenerTodos()
        {
            IQueryable<Pedido> queryPedidoSQL = _dbContext.Pedidos;
            return queryPedidoSQL;
        }
    }
}
