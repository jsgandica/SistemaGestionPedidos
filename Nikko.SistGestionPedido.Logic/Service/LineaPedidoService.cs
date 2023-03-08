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
    public class LineaPedidoService:ILineaPedidoService
    {
        private readonly IGenericRepository<LineaPedido> _lineapedidoService;

        public LineaPedidoService(IGenericRepository<LineaPedido> lineapedidoService)
        {
            _lineapedidoService = lineapedidoService;
        }

        public async Task<bool> Actualizar(LineaPedido lineapedido)
        {
            return await _lineapedidoService.Actualizar(lineapedido);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _lineapedidoService.Eliminar(id);
        }

        public async Task<bool> Insertar(LineaPedido lineapedido)
        {
            return await _lineapedidoService.Insertar(lineapedido);
        }

        public async Task<LineaPedido> Obtener(int id)
        {
            return await _lineapedidoService.Obtener(id);
        }
       
        public async Task<IQueryable<LineaPedido>> ObtenerTodos()
        {
            return await _lineapedidoService.ObtenerTodos();
        }
    }
}
