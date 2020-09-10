using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Logstore.Pedido.Domain.Services;

namespace Logstore.Pedido.Cronjob
{
    public class Program
    {
        protected Program() { }
        public static async Task Main()
        {
            var startUp = new Startup();

            using (var scope = startUp.Scope)
            {
                var logger = scope.ServiceProvider.GetService<ILogger<Program>>();

                logger.LogInformation("Logstore.Pedido.Conjob iniciado!");                

                 await startUp.Scope.ServiceProvider.GetService<IFindInvoiceService>().Executar();                

                logger.LogInformation("Logstore.Pedido.Conjob finalizado!");
            }
        }
    }
}