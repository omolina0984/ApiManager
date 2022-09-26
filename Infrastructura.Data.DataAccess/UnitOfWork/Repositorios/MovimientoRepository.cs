using Dominio.ApiManager.Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructura.Data.DataAccess.UnitOfWork.Repositorios
{
 



  public  class MovimientoRepository : IMovimientoRepository
    {
        private readonly IUnitOfWork _unitOfwork;

        public MovimientoRepository(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;

        }


        public async Task<IEnumerable<Movimiento>> ObtenerTodos()
        {
            return await _unitOfwork.Context.Movimientos.ToListAsync();
        }

        public async Task<Movimiento> GetMovimiento(int id)
        {
            return await _unitOfwork.Context.Movimientos
                .FirstOrDefaultAsync(e => e.CuentaId  == id);
        }

        public async Task<Movimiento> AddMovimiento(Movimiento movimiento)
        {
            var result = await _unitOfwork.Context.Movimientos.AddAsync(movimiento);
             _unitOfwork.Context.SaveChanges();
            return result.Entity;
        }


        //public void Nuevo( Movimiento movimiento)
        //{
        //    //var projection = GetPeople().Select(p => new {p.Username, p.Email});
        //    //return _unitOfwork.Context.Movimientos.Include(x=>x.Cuenta).ToList();
        //    _unitOfwork.Context.Add(movimiento);
        //}
        public  Movimiento UpdateMovimiento(Movimiento movimiento)
        {
            var result = _unitOfwork.Context.Movimientos
                .FirstOrDefault(e => e.MovimientoId == movimiento.MovimientoId);

            if (result != null)
            {
                result.TipoMovimientoId = movimiento.TipoMovimientoId;
                result.Valor = movimiento.Valor;
                result.Fecha = movimiento.Fecha;
                result.Saldo = movimiento.Saldo;
          

                 _unitOfwork.Context.SaveChanges();

                return result;
            }

            return null;
        }


        public  void EliminarMovimiento(int id)
        {

                        var result =  _unitOfwork.Context.Movimientos
                .FirstOrDefault(e => e.MovimientoId == id );
      
            if (result != null)
            {
                _unitOfwork.Context.Movimientos.Remove(result);
                 _unitOfwork.Context.SaveChanges();
            }
        }


        public string  RegistrarMovimiento(Deposito deposito)
        {
            var cuenta = _unitOfwork.Context.Cuenta.FirstOrDefault(e => e.NumeroCuenta == deposito.Cuenta);
            var cliente = _unitOfwork.Context.Clientes.FirstOrDefault(e => e.ClienteId == cuenta.ClienteId);
            var movimientosTope = _unitOfwork.Context.Movimientos.Where(e => e.CuentaId == cuenta.CuentaId && e.Fecha == DateTime.Today);
            var tope = 1000;
            decimal sumadiaria=(decimal)0;
            foreach (var item in movimientosTope)
            {
                if (item.TipoMovimientoId==1)
                {
                    sumadiaria = (decimal)(sumadiaria + item.Valor);
                }
               
            }

            //1 retiro
            if (deposito.tipo == 1)
            {
                var diferencia = tope - sumadiaria;


                if (cuenta.SaldoInicial == 0)
                {
                    return "No dispone de fondos suficientes";
                }

                if (sumadiaria <= tope && diferencia >=deposito.valor)
                {
                    Movimiento nuevo = new Movimiento();
                    nuevo.CuentaId = cuenta.CuentaId;
                    nuevo.TipoMovimientoId = deposito.tipo;
                    nuevo.Valor = deposito.valor;
                    nuevo.Saldo = cuenta.SaldoInicial - deposito.valor;
                    nuevo.Fecha = DateTime.Now;
                    nuevo.Detalle = "Retiro de " + deposito.valor;
                    nuevo.SaldoAnterior = cuenta.SaldoInicial;
                    cuenta.SaldoInicial = nuevo.Saldo;
                    _unitOfwork.Context.Movimientos.Add(nuevo);
                    _unitOfwork.Context.SaveChanges();
                    return "Movimiento registrado";
                }

                if (sumadiaria > tope)
                {
                    return "La transaccion excede el rango permitido por dia";
                }

                if (diferencia < deposito.valor)
                {
                    return "La transaccion excede el rango permitido por dia";
                }

            }
          if(deposito.tipo==2)
            {
                Movimiento nuevo = new Movimiento();
                nuevo.CuentaId = cuenta.CuentaId;
                nuevo.TipoMovimientoId = deposito.tipo;
                nuevo.Valor = deposito.valor;
                nuevo.SaldoAnterior = cuenta.SaldoInicial;
                nuevo.Saldo = cuenta.SaldoInicial + deposito.valor;
                nuevo.Fecha = DateTime.Now;
                nuevo.Detalle = "Deposito de " + deposito.valor;
                cuenta.SaldoInicial = nuevo.Saldo;
                _unitOfwork.Context.Movimientos.Add(nuevo);
                _unitOfwork.Context.SaveChanges();
                return "Movimiento registrado";

            }
            return "";
        }

        public List<Reporte> Reporte(DateTime dateinit, DateTime dateend, string identificacion)
        {
            var db = _unitOfwork.Context;

            var reporte = (from c in _unitOfwork.Context.Clientes
                          join q in _unitOfwork.Context.Cuenta
                          on c.ClienteId equals q.ClienteId
                          join s in _unitOfwork.Context.TipoCuenta
                          on q.TipoCuentaId equals s.TipoCuentaId
                          join t in db.Movimientos
                          on q.CuentaId equals t.CuentaId
                          join w in _unitOfwork.Context.TipoMovimientos
                          on t.TipoMovimientoId equals w.TipoMovimientoId
                          where c.Identificacion == identificacion && t.Fecha > dateinit.AddDays(-1) && t.Fecha < dateend.AddDays(1)
                          select new Reporte
                          {
                              Fecha = t.Fecha,
                              Cliente = c.Nombres,
                              NumeroCuenta = q.NumeroCuenta,
                              Tipo = s.Cuenta,
                              SaldoInicial = t.SaldoAnterior,
                              Estado=q.Estado,
                              Movimiento=t.Valor,
                              Saldo=t.Saldo,
                              TipoTransaccion=w.DescripcionMovimiento,
                              DetalleTransaccion=t.Detalle
                          }).ToList();




            return reporte;
        }


    }
}
