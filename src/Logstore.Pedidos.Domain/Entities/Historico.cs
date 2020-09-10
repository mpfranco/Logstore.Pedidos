using Logstore.Pedidos.Domain.Base;
using System;


namespace Logstore.Pedidos.Domain.Entities
{
    public class Historico : BaseEntity
    {
        public long PedidoId { get; set; }
        public AgregacaoPedido.Pedido Pedido { get; set; }
        public decimal Valor { get; set; }
        public int TotalItens { get; set; }
        public override bool EstaConsistente()
        {
            throw new NotImplementedException();
        }

        public void AssociateId(long id)
        {
            Id = id;
        }
    }
}
