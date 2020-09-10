using Logstore.Pedidos.Domain.Entities;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Base;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Clientes;
using Logstore.Pedidos.Infrastructure.Data.Repository.Base;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logstore.Pedido.Infrastructure.Data.Repository.Clientes
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        
        public ClienteRepository(IConfiguration configuration) : base(configuration)
        {

        }
      
        public async Task<Cliente> SaveAsync(Cliente entity)
        {
            var id = await SaveAsync<long, Cliente>(entity);
            entity.AssociateId(id);
            return entity;
        }

        public async Task<Cliente> FindAsyncById(long id)
        {
            return await FindAsync<Cliente>(id);            
        }
    }
}
