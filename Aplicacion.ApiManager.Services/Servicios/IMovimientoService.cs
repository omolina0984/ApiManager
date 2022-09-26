using Dominio.ApiManager.Entidades.Entidades;
using Infrastructura.Data.DataAccess.UnitOfWork.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ApiManager.Services.Servicios
{
    public interface IMovimientoService
    {
        public Task<IEnumerable<Movimiento>> ObtenerTodos();
        public void EliminarMovimiento(int  id);

        public Task<Movimiento> GetMovimiento(int id);

        public string RegistrarMovimiento(Deposito deposito);
        public Movimiento UpdateMovimiento(Movimiento movimiento);
        public List<Reporte> Reporte(DateTime dateinit, DateTime dateend, string identificacion);
    }
}
