using System;
using System.Collections.Generic;
using System.Data.Entity;
using Repository.Repositories.Base;

namespace Repository.Logic.Repositories.Base
{    
    public class BaseRepositoryCrud<TEntity, TEntitykey> : BaseReadRepository<AxaAltranEntities, TEntity, TEntitykey>, 
        IBaseRepositoryCrud<TEntity, TEntitykey> 
        where TEntity : class
    {
        public BaseRepositoryCrud(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


    }
}
