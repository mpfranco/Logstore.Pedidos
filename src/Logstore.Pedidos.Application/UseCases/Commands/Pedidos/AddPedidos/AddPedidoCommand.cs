using Logstore.Pedidos.Application.Validations;
using Logstore.Pedidos.Application.ViewModels;
using System.Collections.Generic;

namespace Logstore.Pedidos.Application.UseCases.Commands.Pedidos.AddPedidos
{
    public class AddPedidoCommand : CustomValidation
    {
        public AddPedidoCommand(long clientId, ICollection<PedidoItemViewModel> pedidoItens, ClienteViewModel cliente)
        {
            ClientId = clientId;            
            PedidoItens = pedidoItens;
            Cliente = cliente;
        }

        public long Id { get; set; }
        public long ClientId { get; set; }
        public decimal ValorPedido { get; set; }
        public ICollection<PedidoItemViewModel> PedidoItens { get; set; }
        public ClienteViewModel Cliente { get; set; }

        public void AssociateId(long id)
        {
            Id = id;
        }

    }
}
