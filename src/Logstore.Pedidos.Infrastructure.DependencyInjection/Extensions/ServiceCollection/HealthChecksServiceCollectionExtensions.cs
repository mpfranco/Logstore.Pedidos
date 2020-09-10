using Microsoft.Extensions.DependencyInjection;

namespace Logstore.Pedidos.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class HealthChecksServiceCollectionExtensions
    {
        public static void AddCustomHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks();
        }
    }
}
