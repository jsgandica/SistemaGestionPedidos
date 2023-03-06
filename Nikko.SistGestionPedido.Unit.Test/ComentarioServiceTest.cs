using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nikko.SistGestionPedido.DAL.Contracts;
using Nikko.SistGestionPedido.Logic.Contracts;
using Nikko.SistGestionPedido.Logic.Service;
using Nikko.SistGestionPedido.Models;
using Nikko.SistGestionPedido.Unit.Test.MockRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Nikko.SistGestionPedido.Unit.Test
{
    [TestClass]

    public class ComentarioServiceTest
    {
        private static IComentarioService _comentarioService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IComentarioRepository> _comentarioRepository = new ComentarioRepositoryMock()._comentarioRepository;
            _comentarioService = new ComentarioService(_comentarioRepository.Object);
        }

        [TestMethod]

        public async void valida_insercionComentario()
        {
            // Arrancar
            Comentario _comentario = new Comentario()
            {
                Id = 5,
                Fecha = DateTime.Now,
                Comentario1 = "Comentario de Prueba"
                
            };

            //Actuar
            bool resultado = await _comentarioService.Insertar(_comentario);

            //Asegurar
            Assert.IsTrue(resultado);
        }

    }
}
