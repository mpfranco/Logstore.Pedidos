using Logstore.Pedidos.Domain.Entities;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Domain.Interfaces.IRepository.Clientes
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Task<Cliente> SaveAsync(Cliente entity);
        Task<Cliente> FindAsyncById(long id);        
    }
}
