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
    public class ClienteServiceTest
    {
        private static IClienteService _clienteService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IClienteRepository> _clienteRepository = new ClienteRepositoryMock()._clienteRepository;
            _clienteService = new ClienteService(_clienteRepository.Object);
        }

        [TestMethod]

        public async Task valida_insercionCliente()
        {
            // Arrancar
            Cliente _cliente = new Cliente()
            {
                Id = 5,
                Nombre = "Andres",
                Telefono = "04128965321",
                Fecha = DateTime.Parse("05/06/1982")
            };

            //Actuar
            bool resultado = await _clienteService.Insertar(_cliente);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async Task valida_EdicionCliente()
        {
            //Arrancar
            Cliente _cliente = new Cliente()
            {
                Id = 28,
                Nombre = "Andres",
                Telefono = "04128965321",
                Fecha = DateTime.Parse("05/06/1982")
            };

            //Actuar
            bool resultado = await _clienteService.Actualizar(_cliente);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]

        public async Task valida_EliminacionCliente()
        {
            //Arrancar
            int id = 5;
            // Actuar
            bool resultado = await _clienteService.Eliminar(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]

        public async Task valida_ObtenerCliente()
        {
            //Arrancar
            int id = 4;
            //Actuar
            var resultado = await _clienteService.Obtener(id);
            //Asegurar
            Assert.IsNotNull(resultado);
        }
    }
}
