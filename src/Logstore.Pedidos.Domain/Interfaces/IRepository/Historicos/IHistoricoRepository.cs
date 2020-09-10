using Logstore.Pedidos.Domain.Dto;
using Logstore.Pedidos.Domain.Entities;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Domain.Interfaces.IRepository.Historicos
{
    public interface IHistoricoRepository : IRepositoryBase<Historico>
    {        
        Task<IEnumerable<HistoricoDto>> FindAsyncByClienteId(long id);
    }
}
