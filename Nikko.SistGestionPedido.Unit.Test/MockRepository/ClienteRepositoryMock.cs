using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Nikko.SistGestionPedido.DAL;
using Nikko.SistGestionPedido.Logic;
using Nikko.SistGestionPedido.DAL.Contracts;
using Nikko.SistGestionPedido.Models;

namespace Nikko.SistGestionPedido.Unit.Test.MockRepository
{
    public class ClienteRepositoryMock
    {
        public Mock<IClienteRepository> _clienteRepository { get; set; }
        public ClienteRepositoryMock()
        {
            _clienteRepository = new Mock<IClienteRepository>();
        }
    }
}
