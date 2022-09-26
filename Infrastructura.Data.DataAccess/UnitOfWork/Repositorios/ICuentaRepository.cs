using Dominio.ApiManager.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructura.Data.DataAccess.UnitOfWork.Repositorios
{
    public interface ICuentaRepository
    {
        public Task<IEnumerable<Cuentum>> ObtenerTodos();
        public void EliminarCuenta(long cuenta);

        public Task<Cuentum> GetCuenta(long cuenta);

        public Task<Cuentum> AddCuenta(Cuentum Cuenta);
        public Cuentum UpdateCuenta(Cuentum cuenta);

    }
}
