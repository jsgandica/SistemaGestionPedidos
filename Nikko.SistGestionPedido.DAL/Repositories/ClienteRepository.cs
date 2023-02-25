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
    public class ClienteRepository : IGenericRepository<Cliente>
    {
        private readonly PedidosContext _dbContext;

        public ClienteRepository(PedidosContext context)
        {
            _dbContext = context;        
        }
        public async Task<bool> Actualizar(Cliente entity)
        {
            _dbContext.Clientes.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Cliente cliente = _dbContext.Clientes.First(c => c.Id == id);
            _dbContext.Clientes.Remove(cliente);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Cliente entity)
        {
            _dbContext.Clientes.Add(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Cliente> Obtener(int id)
        {
            return await _dbContext.Clientes.FindAsync(id);
        }

        public async Task<IQueryable<Cliente>> ObtenerTodos()
        {
            IQueryable<Cliente> queryClienteSQL = _dbContext.Clientes;
            return queryClienteSQL;
        }
    }
}
