using Logstore.Pedidos.Domain.Base;
using System;
using System.Linq;

namespace Logstore.Pedidos.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente()
        {

        }
        public Cliente(string nome, string telefone, string cpf, long enderecoId)
        {
            Nome = nome;
            Telefone = telefone;
            CPF = cpf;
            EnderecoId = enderecoId;
        }



        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public long EnderecoId { get; set; }
        
        public void AssociateId(long id)
        {
            Id = id;
        }

        public void AssociateEnderecoId(long id)
        {
            EnderecoId = id;
        }

        public override bool EstaConsistente()
        {
            Validar();
            return !ListaErros.Any();
        }

        protected void Validar()
        {
            if (CPF.Length <= 0)
                ListaErros.Add("Favor informe o CPF");
            if (Nome.Length <= 0)
                ListaErros.Add("Favor informe o Nome");
            if (Nome.Length <= 0)
                ListaErros.Add("Favor informe o Telefone");
        }
    }
}
