using Logstore.Pedidos.Domain.Entities;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Produtos;
using Logstore.Pedidos.Infrastructure.Data.Repository.Base;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Infrastructure.Data.Repository.Produtos
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public async Task<Produto> FindById(long Id)
        {
            return await FindAsync<Produto>(Id);
        }
    }
}
