using Logstore.Pedidos.Domain.Base;
using System;


namespace Logstore.Pedidos.Domain.Entities.AgregacaoPedido
{
    public class PedidoItem : BaseEntity
    {
        public PedidoItem(long pedidoId, long produtoId, bool meioaMeio, long produto2Id, decimal valorItem)
        {
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            MeioaMeio = meioaMeio;
            Produto2Id = produto2Id;
            ValorItem = valorItem;
        }

        public long PedidoId { get; private set; }        
        public long ProdutoId { get; private set; }
        public bool MeioaMeio { get; private set; }
        public long? Produto2Id { get; private set; }
        public decimal ValorItem { get; private set; }
                
        public void AssociateId(long id)
        {
            Id = id;
        }
        public void AssociatePedidoId(long id)
        {
            PedidoId = id;
        }

        public override bool EstaConsistente()
        {
            throw new NotImplementedException();
        }
    }
}
