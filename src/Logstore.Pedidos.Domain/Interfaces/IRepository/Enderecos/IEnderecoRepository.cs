using Logstore.Pedidos.Domain.Entities;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Domain.Interfaces.IRepository.Enderecos
{
    public interface IEnderecoRepository
    {
        Task<Endereco> SaveAsync(Endereco entity);
    }
}
