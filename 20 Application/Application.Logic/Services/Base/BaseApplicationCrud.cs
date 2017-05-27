using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using Application.Services.Base;
using Domain.Services.Base;

namespace Application.Logic.Services.Base
{
    public class BaseApplicationCrudLogic<TEntity, TEntityKey> : IBaseApplicationCrud<TEntity, TEntityKey>
    {
        readonly IBaseServiceCrudLogic<TEntity, TEntityKey> _baseServiceCrudLogic;

        public BaseApplicationCrudLogic(IBaseServiceCrudLogic<TEntity, TEntityKey> baseServiceCrudLogic)
        {
            _baseServiceCrudLogic = baseServiceCrudLogic;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return GetAll();
        }

        public TEntity GetById(TEntityKey entityId)
        {
            return GetById(entityId);
        }

  
    }
}
