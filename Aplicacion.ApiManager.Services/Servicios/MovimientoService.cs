using Dominio.ApiManager.Entidades.Entidades;
using Infrastructura.Data.DataAccess.UnitOfWork;
using Infrastructura.Data.DataAccess.UnitOfWork.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ApiManager.Services.Servicios
{
   public class MovimientoService :IMovimientoService
    {
        public readonly IMovimientoRepository _movimientoRepo; 
        public MovimientoService(IMovimientoRepository movimientoRepo)
        {
            _movimientoRepo = movimientoRepo;
            

        }


       public  Task<IEnumerable<Movimiento>> ObtenerTodos()
        {

            return _movimientoRepo.ObtenerTodos();
        }


        public void EliminarMovimiento(int id)
        {
             _movimientoRepo.EliminarMovimiento(id);
        }

        public Task<Movimiento> GetMovimiento(int id)
        {
            return _movimientoRepo.GetMovimiento(id);
        }

        public string RegistrarMovimiento(Deposito deposito)
        {
            return _movimientoRepo.RegistrarMovimiento(deposito);
        }
        public Movimiento UpdateMovimiento(Movimiento movimiento)
        {
            return _movimientoRepo.UpdateMovimiento(movimiento);
        }

        public List<Reporte> Reporte(DateTime dateinit, DateTime dateend, string identificacion)
        {
            return _movimientoRepo.Reporte(dateinit, dateend, identificacion);
        }
    }
}
