using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Logstore.Pedidos.Infrastructure.Shared.Comunication;
using Logstore.Pedidos.Infrastructure.Shared.DomainObjects;
using Logstore.Pedidos.Application.UseCases.Commands.Clientes.AddClient;
using Logstore.Pedidos.Application.UseCases.Commands.Pedidos.AddPedidos;

namespace Logstore.Pedidos.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class MessageBusServiceCollectionExtensions
    {
        public static void AddBus(this IServiceCollection services)
        {
            //Bus (Mediator)
            services.AddMediatR(typeof(ApplicationStartup));
            services.AddScoped<IMediatorBus, MediatorBus>();            
            services.AddScoped<IRequestHandler<AddClientCommand, ResultCommand>, AddClientCommandHandler>();
            services.AddScoped<IRequestHandler<AddPedidoCommand, ResultCommand>, AddPedidoCommandHandler>();            
            
        }
    }
}
