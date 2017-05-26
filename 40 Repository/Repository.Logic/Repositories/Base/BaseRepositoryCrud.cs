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
        
        public TEntity Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.Entry(entity).State = EntityState.Added;
            Save();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            Save();
        }

        public int Update(TEntity entityToUpdate)
        {
            TEntity repositoryEntityToUpdate = GetEntityFromRepositoryToUpdate(entityToUpdate);

            if (repositoryEntityToUpdate == null)
            {
                throw new KeyNotFoundException("Entity doesn't exists");
            }
            else
            {
                Context.Entry(repositoryEntityToUpdate).CurrentValues.SetValues(entityToUpdate);
            }

            return Save();
        }

        protected virtual TEntity GetEntityFromRepositoryToUpdate(TEntity entityToUpdate)
        {           
            throw new NotImplementedException();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }
    }
}
