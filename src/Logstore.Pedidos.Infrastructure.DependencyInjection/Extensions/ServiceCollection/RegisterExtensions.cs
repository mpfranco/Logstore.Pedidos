using Microsoft.Extensions.DependencyInjection;
using Logstore.Pedidos.Infrastructure.Shared.Services;

namespace Logstore.Pedidos.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class RegisterExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {            
            services.AddScoped<ILoggerPedido, LoggerPedido>();  
            return services;
        }
    }
}