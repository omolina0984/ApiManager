using Aplicacion.ApiManager.Services.Servicios;
using Dominio.ApiManager.Entidades.Entidades;
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
    public class ReportesController : ControllerBase
    {
        public readonly IMovimientoService _movimientoService;
        public ReportesController( IMovimientoService movimientoService)
        {

            
            _movimientoService = movimientoService;
        }
        // GET: api/<ReportesController>
        [HttpGet]
        public IEnumerable<Reporte> Get(string dateinit, string dateend, string identificacion)
        {
            var FechaInicial = Convert.ToDateTime(dateinit);
            var FechaFinal = Convert.ToDateTime(dateend);
           

            return _movimientoService.Reporte(FechaInicial, FechaFinal, identificacion);
        }

      
    }
}
