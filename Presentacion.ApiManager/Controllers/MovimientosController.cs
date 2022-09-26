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
    public class MovimientosController : ControllerBase
    {

        public readonly IUnitOfWork _unitOfwork;

        public readonly IMovimientoService _movimientoService;

        public MovimientosController(IUnitOfWork unitOfwork, IMovimientoService movimientoService)
        {

            _unitOfwork = unitOfwork;
            _movimientoService = movimientoService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public Task<IEnumerable<Movimiento>> Get()
        {
            return _movimientoService.ObtenerTodos();
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Task<Movimiento> Get(int id)
        {
            return _movimientoService.GetMovimiento(id);
        }
        // POST api/<ValuesController>
        [HttpPost]
        public string Post([FromBody] Deposito deposito)
        {
          return  _movimientoService.RegistrarMovimiento(deposito);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Movimiento movimiento)
        {
            _movimientoService.UpdateMovimiento(movimiento);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _movimientoService.EliminarMovimiento(id);
        }


        
    }
    }
