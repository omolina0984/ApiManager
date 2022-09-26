using Dominio.ApiManager.Entidades.Entidades;
using Infrastructura.Data.DataAccess.UnitOfWork.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ApiManager.Services.Servicios
{
    public interface ICuentaService
    {
        public Task<IEnumerable<Cuentum>> ObtenerTodos();
        public void EliminarCuenta(long cuenta);

        public Task<Cuentum> GetCuenta(long cuenta);

        public Task<Cuentum> AddCuenta(Cuentum Cuenta);
        public Cuentum UpdateCuenta(Cuentum cuenta);
    }
}
