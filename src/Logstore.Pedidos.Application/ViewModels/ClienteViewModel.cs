

namespace Logstore.Pedidos.Application.ViewModels
{
    public class ClienteViewModel
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
