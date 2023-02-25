using Nikko.SistGestionPedido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikko.SistGestionPedido.Logic.Contracts
{
    public interface IComentarioService
    {
        Task<bool> Insertar(Comentario comentario);
        Task<bool> Actualizar(Comentario comentario);
        Task<bool> Eliminar(int id);

        Task<Comentario> Obtener(int id);

        Task<IQueryable<Comentario>> ObtenerTodos();

    }
}
