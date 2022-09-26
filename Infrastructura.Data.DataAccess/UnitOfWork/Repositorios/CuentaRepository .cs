using Dominio.ApiManager.Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructura.Data.DataAccess.UnitOfWork.Repositorios
{




    public class CuentaRepository : ICuentaRepository
    {
        private readonly IUnitOfWork _unitOfwork;

        public CuentaRepository(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;

        }


        public async Task<IEnumerable<Cuentum>> ObtenerTodos()
        {
            return await _unitOfwork.Context.Cuenta.ToListAsync();
        }

        public async Task<Cuentum> GetCuenta(long cuenta)
        {
            return await _unitOfwork.Context.Cuenta
                .FirstOrDefaultAsync(e => e.NumeroCuenta == cuenta);
        }

        public async Task<Cuentum> AddCuenta(Cuentum cuenta)
        {
            var result = await _unitOfwork.Context.Cuenta.AddAsync(cuenta);
            _unitOfwork.Context.SaveChanges();
            return result.Entity;
        }


        //public void Nuevo( Cliente cliente)
        //{
        //    //var projection = GetPeople().Select(p => new {p.Username, p.Email});
        //    //return _unitOfwork.Context.Clientes.Include(x=>x.Cuenta).ToList();
        //    _unitOfwork.Context.Add(cliente);
        //}
        public Cuentum UpdateCuenta(Cuentum cuenta)
        {
            var result = _unitOfwork.Context.Cuenta
                .FirstOrDefault(e => e.NumeroCuenta == cuenta.NumeroCuenta);

            if (result != null)
            {
                result.NumeroCuenta = cuenta.NumeroCuenta;
                result.TipoCuentaId = cuenta.TipoCuentaId;
                result.SaldoInicial = cuenta.SaldoInicial;
                result.Estado = cuenta.Estado;
              

                _unitOfwork.Context.SaveChanges();

                return result;
            }

            return null;
        }


        public void EliminarCuenta(long cuenta)
        {

            var result = _unitOfwork.Context.Cuenta
    .FirstOrDefault(e => e.NumeroCuenta == cuenta);

            if (result != null)
            {
                _unitOfwork.Context.Cuenta.Remove(result);
                _unitOfwork.Context.SaveChanges();
            }
        }


    }
}
