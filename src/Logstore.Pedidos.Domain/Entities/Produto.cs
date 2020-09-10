using Logstore.Pedidos.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logstore.Pedidos.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public override bool EstaConsistente()
        {
            Validar();
            return !ListaErros.Any();
        }

        protected void Validar()
        {
            if (Descricao.Length <= 0)
                ListaErros.Add("Favor informe a Descrição");
            if (Valor <= 0)
                ListaErros.Add("Favor informe o valor");
            
        }
    }
}
