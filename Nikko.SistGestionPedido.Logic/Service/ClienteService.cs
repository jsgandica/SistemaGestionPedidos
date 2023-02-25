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
    public class ClienteService : IClienteService
    {
        private readonly IGenericRepository<Cliente> _clienteService;

        public ClienteService(IGenericRepository<Cliente> clienteService)
        { 
            _clienteService= clienteService;
        }
        public async Task<bool> Actualizar(Cliente cliente)
        {
            return await _clienteService.Actualizar(cliente);    
        }

        public async Task<bool> Eliminar(int id)
        {
           return await _clienteService.Eliminar(id);
        }

        public async Task<bool> Insertar(Cliente cliente)
        {
            
            return await _clienteService.Insertar(cliente);
        }

        public async Task<Cliente> Obtener(int id)
        {
            return await _clienteService.Obtener(id);
        }

        public async Task<Cliente> ObtenerPorNombre(string nombreCliente)
        {
            IQueryable<Cliente> queryClienteSQL = await _clienteService.ObtenerTodos();
            Cliente cliente= queryClienteSQL.Where(c=>c.Nombre==nombreCliente).FirstOrDefault();
            return cliente;
        }

        public async Task<IQueryable<Cliente>> ObtenerTodos()
        {
            return await _clienteService.ObtenerTodos();
        }
    }
}
