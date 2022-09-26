using Dominio.ApiManager.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructura.Data.DataAccess.UnitOfWork.Repositorios
{
    public interface IClienteRepository
    {
        public Task<IEnumerable<Cliente>> ObtenerTodos();
        public void EliminarCliente(string identificacion);

        public Task<Cliente> GetCliente(string identificacion);

        public Task<Cliente> AddCliente(Cliente cliente);
        public Cliente UpdateClient(Cliente client);

    }
}
