using Moq;
using Nikko.SistGestionPedido.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikko.SistGestionPedido.Unit.Test.MockRepository
{
    public  class VendedorRepositoryMock
    {
        public Mock<IVendedorRepository> _vendedorRepository { get; set; }
        public VendedorRepositoryMock()
        {
            _vendedorRepository = new Mock<IVendedorRepository>();
        }
    }
}
