using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Logstore.Pedidos.Infrastructure.Shared.Settings;


namespace Logstore.Pedidos.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class SettingsServiceCollectionExtensions
    {
        public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            //Settings
            services.Configure<LogStoreSettings>(configuration.GetSection("LogstoreSettings"));
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<LogStoreSettings>>().Value);
            
        }
    }
}
