using Logstore.Pedidos.Api;
using Logstore.Pedidos.Infrastructure.Bootstrap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Pedidos.Application.Tests
{
    public class DbFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }
        public ConfigurationBuilder Configuration { get; set; }
        public DbFixture()
        {
            var services = new ServiceCollection();
            Configuration = new ConfigurationBuilder();
            Configuration.AddJsonFile("appsettings.json");
            IConfiguration configuration = Configuration.Build();
            RegistersServices(services, configuration);
            ServiceProvider = services.BuildServiceProvider();


        }
        private void RegistersServices(IServiceCollection services, IConfiguration configuration)
        {
            Startup app = new Startup(configuration);
            app.ConfigureServices(services);
            services.AddSingleton<IConfiguration>(configuration);
        }

    }
}
