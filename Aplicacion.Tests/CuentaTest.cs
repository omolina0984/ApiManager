using Dominio.ApiManager.Entidades.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentacion.ApiManager.Controllers;
using System.Collections.Generic;

namespace Aplicacion.Tests
{    [TestClass]
    class CuentaTest
    {
        [TestMethod]
        public void GetAllCuenta_ShouldReturnAllCuenta()
        {
            var testC = GetTestCuentass();
            var controller = new CuentasController((ApiManager.Services.Servicios.ICuentaService)testC);

            var result = controller.Get() as IEnumerable<Cuentum>;
            Assert.AreEqual(testC.Count, result);
        }

        [TestMethod]
        public void GetClient_ShouldReturnCorrectClient()
        {
            var test = GetTestCuentass();
            var controller = new CuentasController((ApiManager.Services.Servicios.ICuentaService)test);

            var result = controller.Get(12341);
            Assert.IsNotNull(result);

        }
        private List<Cuentum> GetTestCuentass()
        {
            var testCuenta = new List<Cuentum>();
            testCuenta.Add(new Cuentum { NumeroCuenta = 12341, TipoCuentaId = 1, SaldoInicial = 1000, Estado = true, ClienteId = 1 }); ;
            testCuenta.Add(new Cuentum { NumeroCuenta = 323445, TipoCuentaId = 2, SaldoInicial = 1000, Estado = true, ClienteId = 1 }); ;

            return testCuenta;
        }
    }
}
