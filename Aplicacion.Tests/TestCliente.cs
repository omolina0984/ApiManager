using Dominio.ApiManager.Entidades.Entidades;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentacion.ApiManager.Controllers;
using System.Collections.Generic;


namespace Aplicacion.Tests
{
    [TestClass]
    class TestCliente
    {
        [TestMethod]
        public void GetAllClientes_ShouldReturnAllCliente()
        {
            var testCliente = GetTestClientes();
            var controller = new ClientesController(testCliente);

            var result = controller.Get() as IEnumerable<Cliente>;
            Assert.AreEqual(testCliente.Count, result);
        }

        [TestMethod]
        public void GetClient_ShouldReturnCorrectClient()
        {
            var testCliente = GetTestClientes();
            var controller = new ClientesController(testCliente);

            var result = controller.Get("1724120034");
            Assert.IsNotNull(result);
           
        }
        private List<Cliente> GetTestClientes()
        {
            var testClientes= new List<Cliente>();
            testClientes.Add(new Cliente { ClienteId = 1, Nombres = "Omar Molina", Direccion = "Carapung", Telefono="2033111", Contraseña="12345", Estado=true, Genero="Masculino", Edad=34, Identificacion="1724120055" });;
            testClientes.Add(new Cliente { ClienteId = 1, Nombres = "Jose Molina", Direccion = "Calderon", Telefono="2033111", Contraseña="12345", Estado=true, Genero="Masculino", Edad=34, Identificacion="1724120056" });;
      
            return testClientes;
        }
    }
}
