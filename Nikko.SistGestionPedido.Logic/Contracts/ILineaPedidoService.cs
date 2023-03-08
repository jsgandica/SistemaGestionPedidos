using Nikko.SistGestionPedido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikko.SistGestionPedido.Logic.Contracts
{
    public interface ILineaPedidoService
    {
        Task<bool> Insertar(LineaPedido lineapedido);
        Task<bool> Actualizar(LineaPedido lineapedido);
        Task<bool> Eliminar(int id);

        Task<LineaPedido> Obtener(int id);

        Task<IQueryable<LineaPedido>> ObtenerTodos();
       
    }
}
