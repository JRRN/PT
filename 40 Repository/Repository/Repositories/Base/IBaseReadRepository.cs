using System;
using System.Collections.Generic;

namespace Repository.Repositories.Base
{
    public interface IBaseReadRepository<TEntity, TEntityKey> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(TEntityKey entityId);

        bool ExistsId(TEntityKey id);
    }
}