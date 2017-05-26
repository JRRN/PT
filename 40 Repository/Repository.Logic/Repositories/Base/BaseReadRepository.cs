using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repository.Logic.Repositories.Base
{
    public class BaseReadRepository<TUnitOfWork,TEntity, TEntityKey> : BaseRepository<TUnitOfWork, TEntity> 
        where TUnitOfWork : DbContext
        where TEntity : class 
    {
        public BaseReadRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(TEntityKey entityId)
        {
            var repositoryEntity =  Context.Set<TEntity>().Find(entityId);

            if(repositoryEntity == null)
            {
                throw new KeyNotFoundException();
            }

            return repositoryEntity;
        }

        public bool ExistsId(TEntityKey id)
        {
            var exists = false;
            try
            {
                var repositoryEntity = GetById(id);
                exists = true;
            }
            catch (KeyNotFoundException)
            {
                exists = false;
            }         
            
            return exists;
        }
    }
}