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
    public class VendedorService: IVendedorService
    {
        private readonly IGenericRepository<Vendedor> _vendedorService;

        public VendedorService(IGenericRepository<Vendedor> vendedorService)
        {
            _vendedorService = vendedorService;
        }

        public async Task<bool> Actualizar(Vendedor vendedor)
        {
            return await _vendedorService.Actualizar(vendedor);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _vendedorService.Eliminar(id);
        }

        public async Task<bool> Insertar(Vendedor vendedor)
        {

            return await _vendedorService.Insertar(vendedor);
        }


        public async Task<Vendedor> Obtener(int id)
        {
            return await _vendedorService.Obtener(id);
        }

        public async Task<IQueryable<Vendedor>> ObtenerTodos()
        {
            return await _vendedorService.ObtenerTodos();
        }

    }
}
