using Logstore.Pedidos.Domain.Entities;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Produtos;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Application.UseCases.Queries.Produtos
{
    public class FindProdutoQuerie : IFindProdutoQuerie
    {
        private readonly IProdutoRepository _repository;
        public FindProdutoQuerie(IProdutoRepository repository)
        {
            _repository = repository;
        }
        public async Task<Produto> FindById(long Id)
        {
            return await _repository.FindById(Id);
        }
    }
}
