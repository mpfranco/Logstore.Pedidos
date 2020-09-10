using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Clientes;
using Logstore.Pedido.Infrastructure.Data.Repository.Clientes;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Pedidos;
using Logstore.Pedidos.Infrastructure.Data.Repository.Produtos;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Produtos;
using Logstore.Pedidos.Infrastructure.Data.Repository.Pedidos;
using Logstore.Pedidos.Infrastructure.Data.Repository.Enderecos;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Enderecos;
using Logstore.Pedidos.Infrastructure.Data.Repository.Historicos;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Historicos;

namespace Logstore.Pedidos.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class RepositoryCollectionExtensions
    {
        public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
        {                        
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IHistoricoRepository, HistoricoRepository>();

        }
    }
}
