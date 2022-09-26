using Aplicacion.ApiManager.Services.Servicios;
using Dominio.ApiManager.Entidades.Entidades;
using Infrastructura.Data.DataAccess.UnitOfWork;
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
    public class CuentasController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfwork;

        public readonly ICuentaService _cuentaService;

        public CuentasController( ICuentaService cuentaService)
        {

          
            _cuentaService = cuentaService;
        }
        // GET: api/<CuentasController>
        [HttpGet]
        public Task<IEnumerable<Cuentum>> Get()
        {
            return _cuentaService.ObtenerTodos();
        }


        // GET api/<CuentasController>/5
        [HttpGet("{cuenta}")]
        public Task<Cuentum> Get(long cuenta)
        {
            return _cuentaService.GetCuenta(cuenta);
        }

        // POST api/<CuentasController>
        [HttpPost]
        public void Post([FromBody] Cuentum cuenta)
        {
            _cuentaService.AddCuenta(cuenta);
        }

        // PUT api/<CuentasController>/5
        [HttpPut("{cuenta}")]
        public void Put(long cuenta, [FromBody] Cuentum cuentan)
        {
            _cuentaService.UpdateCuenta(cuentan);

        }

        // DELETE api/<CuentasController>/5
        [HttpDelete("{cuenta}")]
        public void Delete(long cuenta)
        {
            _cuentaService.EliminarCuenta(cuenta);
        }
    }
}
