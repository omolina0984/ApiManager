using Dominio.ApiManager.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructura.Data.DataAccess.UnitOfWork.Repositorios
{
    public interface IMovimientoRepository
    {
        public Task<IEnumerable<Movimiento>> ObtenerTodos();
        public void EliminarMovimiento(int id);

        public Task<Movimiento> GetMovimiento(int id);

        public string RegistrarMovimiento(Deposito deposito);
        public Movimiento UpdateMovimiento(Movimiento movimiento);
        public List<Reporte> Reporte(DateTime dateinit, DateTime dateend, string identificacion);

    }
}
