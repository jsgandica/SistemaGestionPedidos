using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikko.SistGestionPedido.DAL.Contracts
{
    public  interface IGenericRepository<TEntityModel> where TEntityModel : class
    {
        Task<bool> Insertar(TEntityModel entity);
        Task<bool> Actualizar(TEntityModel entity);

        Task<bool> Eliminar(int id);
        Task<TEntityModel> Obtener(int id);
        Task<IQueryable<TEntityModel>> ObtenerTodos();
    }
}
