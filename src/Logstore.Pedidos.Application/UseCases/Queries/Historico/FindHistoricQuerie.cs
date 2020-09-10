using Logstore.Pedidos.Domain.Dto;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Historicos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Application.UseCases.Queries.Historico
{
    public class FindHistoricQuerie : IFindHistoricQuerie
    {
        private readonly IHistoricoRepository _repository;

        public FindHistoricQuerie(IHistoricoRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<HistoricoDto>> FindAsyncByClienteId(long id)
        {
            return await _repository.FindAsyncByClienteId(id);
        }
    }
}
