using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Services.Base
{
    public interface IBaseServiceReadLogic<TEntity, TEntityKey>

    {
        TEntity GetById(TEntityKey entityId);

        IEnumerable<TEntity> GetAll();
    }
}
