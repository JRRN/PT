using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Logic.Repositories.Base
{
    public class BaseReadRepository<TUnitOfWork,TEntity, TEntityKey> : BaseRepository<TUnitOfWork, TEntity> 
        where TUnitOfWork : DbContext
        where TEntity : class 
    {
        public BaseReadRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity,bool>> predicate)
        {
           return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity GetById(TEntityKey entityId)
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