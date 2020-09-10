using Logstore.Pedidos.Domain.Entities;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Application.UseCases.Queries.Clientes
{
    public interface IFindClientQuerie
    {
        Task<Cliente> FindAsyncById(long id);
    }
}
