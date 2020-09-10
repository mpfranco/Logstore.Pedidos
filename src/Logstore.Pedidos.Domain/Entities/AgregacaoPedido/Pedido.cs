using Logstore.Pedidos.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Logstore.Pedidos.Domain.Entities.AgregacaoPedido
{
    public class Pedido : BaseEntity
    {
        public Pedido(long clienteId, decimal valorPedido, ICollection<PedidoItem> pedidoItens)
        {
            ClienteId = clienteId;
            Valor = valorPedido;
            PedidoItens = pedidoItens;
        }

        public long ClienteId { get; private set; }
        public decimal Valor { get; private set; }
        
        [NotMapped]
        public ICollection<PedidoItem> PedidoItens { get; private set; }        
        public void AssociateId(long id)
        {
            Id = id;
        }

        public override bool EstaConsistente()
        {
            Validar();
            return !ListaErros.Any();
        }

        protected void Validar()
        {
            if (PedidoItens.Count() > 10)
                ListaErros.Add("A quantidade de itens permitida por pedido é de 10 itens e foi informado " + PedidoItens.Count());
            if (PedidoItens.Count() < 1)
                ListaErros.Add("Pedido não possui itens");            
        }
    }
}
