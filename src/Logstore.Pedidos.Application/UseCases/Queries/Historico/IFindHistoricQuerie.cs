using Logstore.Pedidos.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Application.UseCases.Queries.Historico
{
    public interface IFindHistoricQuerie
    {
        Task<IEnumerable<HistoricoDto>> FindAsyncByClienteId(long id);
    }
}
