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
   public class ClienteService :IClienteService
    {
        public readonly IClienteRepository _clienteRepo; 
        public ClienteService(IClienteRepository clienteRepo)
        {
            _clienteRepo = clienteRepo;
            

        }


       public  Task<IEnumerable<Cliente>> ObtenerTodos()
        {

            return _clienteRepo.ObtenerTodos();
        }


        public void EliminarCliente(string identificacion)
        {
             _clienteRepo.EliminarCliente(identificacion);
        }

        public Task<Cliente> GetCliente(string identificacion)
        {
            return _clienteRepo.GetCliente(identificacion);
        }

        public Task<Cliente> AddCliente(Cliente cliente)
        {
            return _clienteRepo.AddCliente(cliente);
        }
        public Cliente UpdateClient(Cliente client)
        {
            return _clienteRepo.UpdateClient(client);
        }

    }
}
