using Logstore.Pedidos.Domain.Entities;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Clientes;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Application.UseCases.Queries.Clientes
{
    public class FindClientQuerie : IFindClientQuerie
    {
        private readonly IClienteRepository _repository;
        public FindClientQuerie(IClienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<Cliente> FindAsyncById(long id)
        {
            return await _repository.FindAsyncById(id);
        }
    }
}
