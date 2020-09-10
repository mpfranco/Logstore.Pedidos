using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Logstore.Pedido.Infrastructure.Bootstrap.Extensions.ServiceCollection;
using System;
using System.IO;
using Logstore.Pedido.Application.UseCases.Services;
using Logstore.Pedido.Domain.Services;
using RestSharp;

namespace Logstore.Pedido.Cronjob
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private ServiceProvider ServiceProvider { get; }

        public IServiceScope Scope => ServiceProvider.CreateScope();

        public Startup()
        {
            //Obter a env
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //setup our configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            if (!string.IsNullOrWhiteSpace(envName))
                builder.AddJsonFile($"appsettings.{envName}.json", optional: true);

            //if (!string.IsNullOrWhiteSpace(envName) && !envName.Equals("Local", StringComparison.InvariantCultureIgnoreCase))
            //    builder.AddConfigServer(envName);

            Configuration = builder.Build();

            //setup our DI
            var servicesBuilder = new ServiceCollection()
                .AddLogging(config =>
                {
                    config.AddConfiguration(Configuration.GetSection("Logging"));
                    config.AddConsole();
                    config.AddDebug();
                });

            ConfigureServices(servicesBuilder);

            ServiceProvider = servicesBuilder.BuildServiceProvider();
        }

        public void ConfigureServices(IServiceCollection services)
        {           
            //services.AddScoped<RestClient>();
            services.AddScoped(x => { return Configuration; });
            services.AddRepository(Configuration);
            services.AddDependencyInjection();
            services.AddSettings(Configuration);
            services.AddBus();
            services.AddApplicationQueries();
            //services.AddPolicies();

        }

    }
}