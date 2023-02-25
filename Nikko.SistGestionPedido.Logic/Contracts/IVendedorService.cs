using Nikko.SistGestionPedido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikko.SistGestionPedido.Logic.Contracts
{
    public interface IVendedorService
    {
        Task<bool> Insertar(Vendedor vendedor);
        Task<bool> Actualizar(Vendedor vendedor);
        Task<bool> Eliminar(int id);

        Task<Vendedor> Obtener(int id);

        Task<IQueryable<Vendedor>> ObtenerTodos();
    }
}
