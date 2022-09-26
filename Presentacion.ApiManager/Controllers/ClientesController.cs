using Aplicacion.ApiManager.Services.Servicios;
using Dominio.ApiManager.Entidades.Entidades;
using Infrastructura.Data.DataAccess.UnitOfWork;
using Infrastructura.Data.DataAccess.UnitOfWork.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentacion.ApiManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
  

        public readonly IClienteService _clienteService;
        private List<Cliente> testProducts;

        public ClientesController( IClienteService clienteService)
        {

         
            _clienteService = clienteService;
        }



        // GET: api/<ClientesController>
        [HttpGet]
 
        public  Task<IEnumerable<Cliente>> Get()
        {
            return _clienteService.ObtenerTodos();
        }

        // GET api/<ClientesController>/1724120033
        [HttpGet("{identificacion}")]
        public Task<Cliente> Get(string identificacion)
        {
            return _clienteService.GetCliente(identificacion);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public void Post([FromBody] Cliente cliente)
        {
            _clienteService.AddCliente(cliente);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{identificacion}")]
        public void Put(string identificacion, [FromBody] Cliente cliente)
        {
            _clienteService.UpdateClient(cliente);
         
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{identificacion}")]
        public void Delete(string identificacion)
        {
            _clienteService.EliminarCliente(identificacion);
        }
    }
}
