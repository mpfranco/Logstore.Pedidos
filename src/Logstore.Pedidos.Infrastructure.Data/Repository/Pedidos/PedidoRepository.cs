using Logstore.Pedidos.Domain.Entities.AgregacaoPedido;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Pedidos;
using Logstore.Pedidos.Infrastructure.Data.Repository.Base;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Infrastructure.Data.Repository.Pedidos
{
    public class PedidoRepository : RepositoryBase<Domain.Entities.AgregacaoPedido.Pedido>, IPedidoRepository
    {
        public PedidoRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public async Task<Domain.Entities.AgregacaoPedido.Pedido> SaveAsync(Domain.Entities.AgregacaoPedido.Pedido entity)
        {
            var id = await SaveAsync<long, Domain.Entities.AgregacaoPedido.Pedido>(entity);
            var itens = await SaveAsyncItens(entity.PedidoItens, id);
            entity.AssociateId(id);            
            return entity;
        }

        public async Task<IEnumerable<PedidoItem>> SaveAsyncItens(IEnumerable<PedidoItem> entities, long pedidoId)
        {
            foreach (var entity in entities)
            {
                entity.AssociatePedidoId(pedidoId);             
                var idItem = await SaveAsync<long, PedidoItem>(entity);
                entity.AssociateId(idItem);
            }
                        
            return entities;
        }
    }
}
