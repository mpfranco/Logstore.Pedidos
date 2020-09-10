using System.Collections.Generic;

namespace Logstore.Pedidos.Application.ViewModels
{
    public class PedidoViewModel
    {
        public long ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public ICollection<PedidoItemViewModel> PedidoItens { get; set; }
    }
}
