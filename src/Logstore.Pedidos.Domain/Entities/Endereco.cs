using Logstore.Pedidos.Domain.Base;
using System;


namespace Logstore.Pedidos.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public Endereco(string logradouro, string numero, string complemento, string bairro, string cidade, string estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }        

        public void AssociateId(long id)
        {
            Id = id;
        }
        public override bool EstaConsistente()
        {
            throw new NotImplementedException();
        }
    }
}
