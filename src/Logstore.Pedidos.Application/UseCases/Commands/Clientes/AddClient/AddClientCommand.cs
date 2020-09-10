

using Logstore.Pedidos.Application.Validations;

namespace Logstore.Pedidos.Application.UseCases.Commands.Clientes.AddClient
{
    public class AddClientCommand : CustomValidation
    {
        public AddClientCommand(string nome, string telefone, string cpf)
        {
            Nome = nome;
            Telefone = telefone;
            CPF = cpf;         
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        
        public void AssociateId(long id)
        {
            Id = id;
        }
    }
}
