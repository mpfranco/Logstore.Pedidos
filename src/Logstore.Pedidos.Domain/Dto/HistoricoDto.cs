using System;


namespace Logstore.Pedidos.Domain.Dto
{
    public class HistoricoDto
    {
        public long PedidoId { get; set; }
        public DateTime DataPedido { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public decimal ValorItem { get; set; }
        public decimal ValorPedido { get; set; }
        public string MeioaMeio { get; set; }
        public string Descricao { get; set; }


    }
}
