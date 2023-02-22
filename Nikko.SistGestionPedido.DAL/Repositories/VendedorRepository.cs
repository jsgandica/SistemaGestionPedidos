using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nikko.SistGestionPedido.DAL.Contracts;
using Nikko.SistGestionPedido.DAL.DataContext;
using Nikko.SistGestionPedido.Models;

namespace Nikko.SistGestionPedido.DAL.Repositories
{
    public class VendedorRepository:IGenericRepository<Vendedor>
    {
        private readonly PruebaContext _dbContext;
        public VendedorRepository(PruebaContext context)
        {
             _dbContext = context;
        }

        public async Task<bool> Actualizar(Vendedor entity)
        {
            _dbContext.Vendedors.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Vendedor vendedor = _dbContext.Vendedors.First(c => c.Id == id);
            _dbContext.Vendedors.Remove(vendedor);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Vendedor entity)
        {
            _dbContext.Vendedors.Add(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Vendedor> Obtener(int id)
        {
            return await _dbContext.Vendedors.FindAsync(id);

        }

        public async Task<IQueryable<Vendedor>> ObtenerTodos()
        {
            IQueryable<Vendedor> queryVendedorSQL = _dbContext.Vendedors;
            return queryVendedorSQL;
        }
    }
}
