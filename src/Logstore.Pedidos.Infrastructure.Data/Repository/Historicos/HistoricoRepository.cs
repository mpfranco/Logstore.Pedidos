using Logstore.Pedidos.Domain.Dto;
using Logstore.Pedidos.Domain.Entities;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Historicos;
using Logstore.Pedidos.Infrastructure.Data.Repository.Base;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Infrastructure.Data.Repository.Historicos
{
    public class HistoricoRepository : RepositoryBase<Historico>, IHistoricoRepository
    {
        private const string querieHistoricoClienteId = "SELECT P.Id as PedidoId,P.DataInclusao as DataPedido,C.Nome,C.Cpf,C.Telefone,E.Logradouro,I.ValorItem,P.Valor As ValorPedido,Case I.MeioaMeio when 1 then Prod.Descricao + ' - ' + Prod2.Descricao Else Prod.Descricao end as Descricao, Case I.MeioaMeio when 1 then 'Sim' 	 Else 'Não' end as MeioaMeio FROM Cliente C Inner Join Endereco E on E.Id = C.EnderecoId Inner Join Pedido P on c.Id = P.ClienteId Inner Join PedidoItem I on P.Id = I.PedidoId Inner Join Produto Prod on Prod.Id = I.ProdutoId Left Join  Produto Prod2 on Prod2.Id = I.Produto2Id Where P.ClienteId = @Id";
        public HistoricoRepository(IConfiguration configuration) : base(configuration)
        {

        }

       
        public async Task<IEnumerable<HistoricoDto>> FindAsyncByClienteId(long Id)
        {
            var result = await QueryAsync<HistoricoDto>(querieHistoricoClienteId, new { Id = Id });
            return result;

        }
    }
}
