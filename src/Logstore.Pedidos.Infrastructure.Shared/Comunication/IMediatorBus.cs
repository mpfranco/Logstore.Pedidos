using Logstore.Pedidos.Infrastructure.Shared.DomainObjects;
using Logstore.Pedidos.Infrastructure.Shared.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Infrastructure.Shared.Comunication
{
    public interface IMediatorBus
    {
        Task PublishEventAsync<T>(T @event) where T : Event;
        Task<ResultCommand> SendCommadAsync<T>(T command) where T : Command;
        Task<ResultCommand<T2>> SendCommadAsync<T, T2>(T command) where T : Command<T2>;
    }
}
