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
    public class PedidoService : IPedidoService
    {
        private readonly IGenericRepository<Pedido> _pedidoService;

        public PedidoService(IGenericRepository<Pedido> pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public async Task<bool> Actualizar(Pedido pedido)
        {
            return await _pedidoService.Actualizar(pedido);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _pedidoService.Eliminar(id);
        }

        public async Task<bool> Insertar(Pedido pedido)
        {
            return await _pedidoService.Insertar(pedido);
        }

        public async Task<Pedido> Obtener(int id)
        {
            return await _pedidoService.Obtener(id);
        }

        public async Task<IQueryable<Pedido>> ObtenerTodos()
        {
            return await _pedidoService.ObtenerTodos();
        }
    }
}
