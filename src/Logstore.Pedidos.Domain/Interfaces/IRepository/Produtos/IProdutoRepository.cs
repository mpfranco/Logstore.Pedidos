using Logstore.Pedidos.Domain.Entities;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Domain.Interfaces.IRepository.Produtos
{
    public interface IProdutoRepository
    {
        Task<Produto> FindById(long Id);
    }
}
