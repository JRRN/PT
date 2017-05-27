using System.Collections.Generic;

namespace Application.Services.Base
{
    public interface IBaseReadApplication<TEntity, TEntityKey>
    {
        TEntity GetById(TEntityKey entityId);

    }
}
