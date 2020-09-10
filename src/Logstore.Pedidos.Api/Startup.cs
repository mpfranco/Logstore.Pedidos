using System.Collections.Generic;
using System.Globalization;
using Easydocs.GetImagem.Api.Filter;
using Logstore.Pedidos.Infrastructure.Bootstrap.Extensions.ServiceCollection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Logstore.Pedidos.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(RequestFilterAttribute));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddControllers();
            services.AddScoped(x => { return Configuration; });
            services.AddRepository(Configuration);
            services.AddDependencyInjection();
            services.AddSettings(Configuration);
            services.AddBus();
            services.AddApplicationQueries();
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {                
                app.UseHsts();
            }




            //var options = new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture("pt-BR"),
            //    SupportedCultures = new List<CultureInfo>() {
            //    CultureInfo.GetCultureInfo("en-US")
            //    }
            //};

            //app.UseRequestLocalization(options);

            //app.UseHangfireDashboard();
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Discount and Scholarship API");
            //});
            app.UseCors("AllowSpecificOrigin");
            app.UseStaticFiles();
            //app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
