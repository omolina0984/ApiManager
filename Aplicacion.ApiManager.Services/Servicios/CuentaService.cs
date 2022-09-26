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
   public class CuentaService :ICuentaService
    {
        public readonly ICuentaRepository _cuentaRepo; 
        public CuentaService(ICuentaRepository cuentaRepo)
        {
            _cuentaRepo = cuentaRepo;
            

        }


       public  Task<IEnumerable<Cuentum>> ObtenerTodos()
        {

            return _cuentaRepo.ObtenerTodos();
        }


        public void EliminarCuenta(long cuenta)
        {
             _cuentaRepo.EliminarCuenta(cuenta);
        }

        public Task<Cuentum> GetCuenta(long cuenta)
        {
            return _cuentaRepo.GetCuenta(cuenta);
        }

        public Task<Cuentum> AddCuenta(Cuentum cuenta)
        {
            return _cuentaRepo.AddCuenta(cuenta);
        }
        public Cuentum UpdateCuenta(Cuentum cuenta)
        {
            return _cuentaRepo.UpdateCuenta(cuenta);
        }

    }
}
