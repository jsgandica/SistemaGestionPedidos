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
    public class VendedorServiceTest
    {
        private static IVendedorService _vendedorService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IVendedorRepository> _vendedorRepository = new VendedorRepositoryMock()._vendedorRepository;
            _vendedorService = new VendedorService(_vendedorRepository.Object);
        }

        [TestMethod]

        public async void valida_insercionVendedor()
        {
            // Arrancar
            Vendedor _vendedor = new Vendedor()
            {
                Id = 5,
                Nombre = "Andres",
                Rowguid = Guid.NewGuid()
                
            };

            //Actuar
            bool resultado = await _vendedorService.Insertar(_vendedor);

            //Asegurar
            Assert.IsTrue(resultado);
        }



        [TestMethod]
        public async void valida_EdicionVendedor()
        {
            //Arrancar
            Vendedor _vendedor = new Vendedor()
            {
                Id = 5,
                Nombre = "Juan"
            };

            //Actuar
            bool resultado = await _vendedorService.Actualizar(_vendedor);

            //Asegurar
            Assert.IsTrue(resultado);
        }


        [TestMethod]

        public async void valida_EliminacionVendedor()
        {
            //Arrancar
            int id = 5;
            // Actuar
            bool resultado = await _vendedorService.Eliminar(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

    }
}
