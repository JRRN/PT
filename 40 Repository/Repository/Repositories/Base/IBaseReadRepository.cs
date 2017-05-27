using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories.Base
{
    public interface IBaseReadRepository<TEntity, TEntityKey> : IDisposable where TEntity : class
    {
        TEntity GetById(TEntityKey entityId);

        bool ExistsId(TEntityKey id);

        IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();

    }
}