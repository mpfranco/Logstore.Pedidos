using Microsoft.Extensions.DependencyInjection;
using Logstore.Pedidos.Application.UseCases.Queries.Clientes;
using Logstore.Pedidos.Application.UseCases.Queries.Historico;
using Logstore.Pedidos.Application.UseCases.Queries.Pedidos;
using Logstore.Pedidos.Application.UseCases.Queries.Produtos;

namespace Logstore.Pedidos.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class ApplicationQueriesCollectionExtensions
    {
        public static void AddApplicationQueries(this IServiceCollection services)
        {            
            services.AddScoped<IFindHistoricQuerie, FindHistoricQuerie>();
            services.AddScoped<IFindClientQuerie, FindClientQuerie>();
            services.AddScoped<IFindPedidoQuerie, FindPedidoQuerie>();
            services.AddScoped<IFindProdutoQuerie, FindProdutoQuerie>();
        }
    }
}
