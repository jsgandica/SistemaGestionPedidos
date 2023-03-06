using Moq;
using Nikko.SistGestionPedido.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikko.SistGestionPedido.Unit.Test.MockRepository
{
    public  class ComentarioRepositoryMock
    {
        public Mock<IComentarioRepository> _comentarioRepository { get; set; }
        public ComentarioRepositoryMock()
        {
            _comentarioRepository = new Mock<IComentarioRepository>();
        }
    }
}
