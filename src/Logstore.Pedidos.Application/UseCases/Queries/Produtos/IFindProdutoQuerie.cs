using Logstore.Pedidos.Domain.Entities;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Application.UseCases.Queries.Produtos
{
    public interface IFindProdutoQuerie
    {
        Task<Produto> FindById(long Id);
    }
}
