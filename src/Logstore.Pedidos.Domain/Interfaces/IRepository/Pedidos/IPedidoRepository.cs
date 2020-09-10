
using Logstore.Pedidos.Domain.Entities.AgregacaoPedido;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Domain.Interfaces.IRepository.Pedidos
{
    public interface IPedidoRepository : IRepositoryBase<Pedido>
    {
        Task<Pedido> SaveAsync(Pedido entity);
        Task<IEnumerable<PedidoItem>> SaveAsyncItens(IEnumerable<PedidoItem> entities, long pedidoId);
    }
}
