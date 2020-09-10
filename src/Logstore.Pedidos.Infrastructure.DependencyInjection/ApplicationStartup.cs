using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Logstore.Pedidos.Infrastructure.Bootstrap.Extensions.ServiceCollection;

namespace Logstore.Pedidos.Infrastructure.Bootstrap
{
    public class ApplicationStartup
    {
        private readonly IConfiguration configuration;

        public ApplicationStartup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddMetrics();

            services.AddCustomHealthChecks();

            services.AddDependencyInjection();
                        
        }

        public void Configure(IApplicationBuilder app)
        {
            
            app.UseMvc();
        }
    }
}