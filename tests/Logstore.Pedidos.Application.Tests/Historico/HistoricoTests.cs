using Logstore.Pedidos.Application.UseCases.Queries.Historico;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Logstore.Pedidos.Application.Tests.Historico
{
    public class HistoricoTests : IClassFixture<DbFixture>
    {
        private readonly IFindHistoricQuerie _querie;
        public HistoricoTests(DbFixture fixture)
        {
            var serviceProvider = fixture.ServiceProvider;
            _querie = serviceProvider.GetService<IFindHistoricQuerie>();            
        }

        [Fact(DisplayName = "Pedidos Clientes Localizados")]
        [Trait("Categoria", "Historico")]
        public async Task PesquisarHistoricoPedidos_HistoricoPedidoCliente_DeveRetornarHistoricoComSucesso()
        {

            //Arrange 
            var clienteId = 1;

            //Act
            var historico = await _querie.FindAsyncByClienteId(clienteId);

            //Assert
            Assert.True(historico.Count() > 0);
        }

        [Fact(DisplayName = "Pedidos Clientes Não Localizados")]
        [Trait("Categoria", "Historico")]
        public async Task PesquisarHistoricoPedidos_HistoricoPedidoCliente_DeveRetornarNaoLocalizado()
        {

            //Arrange 
            var clienteId = 10;

            //Act
            var historico = await _querie.FindAsyncByClienteId(clienteId);

            //Assert
            Assert.True(historico.Count() <= 0);
        }

    }
}
