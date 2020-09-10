using System;

namespace Logstore.Pedidos.Domain.Interfaces.IRepository.Base
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {

    }
}
