using Logstore.Pedidos.Domain.Entities;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Enderecos;
using Logstore.Pedidos.Infrastructure.Data.Repository.Base;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Infrastructure.Data.Repository.Enderecos
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public async Task<Endereco> SaveAsync(Endereco entity)
        {
            var id = await SaveAsync<long, Endereco>(entity);
            entity.AssociateId(id);
            return entity;
        }
    }
}
