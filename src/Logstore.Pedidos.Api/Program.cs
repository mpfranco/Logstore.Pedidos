using Logstore.Pedidos.Api;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace Easydocs.GetImagem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.ConfigureKestrel(options => { options.AddServerHeader = false; })
                //.UseKestrel( options => { options.AddServerHeader = false; })  
                //.UseIIS()
                //.UseIISIntegration()
                .UseStartup<Startup>();
    }
}
