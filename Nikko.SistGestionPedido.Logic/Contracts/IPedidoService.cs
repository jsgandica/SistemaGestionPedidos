using Nikko.SistGestionPedido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikko.SistGestionPedido.Logic.Contracts
{
    public interface IPedidoService
    {
        Task<bool> Insertar(Pedido pedido);
        Task<bool> Actualizar(Pedido pedido);
        Task<bool> Eliminar(int id);
        Task<Pedido> Obtener(int id);
        Task<IQueryable<Pedido>> ObtenerTodos();
    }
}
