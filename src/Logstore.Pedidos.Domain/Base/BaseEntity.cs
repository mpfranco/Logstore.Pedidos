using System;
using System.Collections.Generic;


namespace Logstore.Pedidos.Domain.Base
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public long UsuarioInclusaoId { get; set; }
        public long UsuarioAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public bool Deleted { get; set; }
        public List<string> ListaErros { get; set; }

        public BaseEntity()
        {
            ListaErros = new List<string>();
            DataInclusao = DateTime.Now;
            DataAlteracao = DateTime.Now;
            Deleted = false;
            UsuarioAlteracaoId = 1;
            UsuarioInclusaoId = 1;
        }

        abstract public bool EstaConsistente();
    }
}
