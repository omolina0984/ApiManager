using Dominio.ApiManager.Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructura.Data.DataAccess.UnitOfWork.Repositorios
{
 



  public  class ClienteRepository: IClienteRepository
    {
        private readonly IUnitOfWork _unitOfwork;

        public ClienteRepository(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;

        }


        public async Task<IEnumerable<Cliente>> ObtenerTodos()
        {
            return await _unitOfwork.Context.Clientes.Include(x => x.Cuenta).ThenInclude(y => y.Movimientos).Include(x => x.Cuenta).ThenInclude(v => v.TipoCuenta).ToListAsync();
        }

        public async Task<Cliente> GetCliente(string identificacion)
        {
            return await _unitOfwork.Context.Clientes
                .FirstOrDefaultAsync(e => e.Identificacion  == identificacion);
        }

        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            var result = await _unitOfwork.Context.Clientes.AddAsync(cliente);
             _unitOfwork.Context.SaveChanges();
            return result.Entity;
        }


        //public void Nuevo( Cliente cliente)
        //{
        //    //var projection = GetPeople().Select(p => new {p.Username, p.Email});
        //    //return _unitOfwork.Context.Clientes.Include(x=>x.Cuenta).ToList();
        //    _unitOfwork.Context.Add(cliente);
        //}
        public  Cliente UpdateClient(Cliente client)
        {
            var result = _unitOfwork.Context.Clientes
                .FirstOrDefault(e => e.Identificacion == client.Identificacion);

            if (result != null)
            {
                result.Nombres = client.Nombres;
                result.Direccion = client.Direccion;
                result.Telefono = client.Telefono;
                result.Contraseña = client.Contraseña;
                result.Estado = client.Estado;
                result.Genero = client.Genero;
                result.Edad = client.Edad;

                 _unitOfwork.Context.SaveChanges();

                return result;
            }

            return null;
        }


        public  void EliminarCliente(string identificacion)
        {

                        var result =  _unitOfwork.Context.Clientes
                .FirstOrDefault(e => e.Identificacion == identificacion );
      
            if (result != null)
            {
                _unitOfwork.Context.Clientes.Remove(result);
                 _unitOfwork.Context.SaveChanges();
            }
        }


    }
}
