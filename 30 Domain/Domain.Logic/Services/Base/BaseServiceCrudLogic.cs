using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Domain.Services.Base;
using Repository.Repositories.Base;

namespace Domain.Logic.Services.Base
{
    public class BaseServiceCrudLogic<TDomainEntity, TRepositoryEntity>:
        BaseServiceLogic<TDomainEntity, TRepositoryEntity>
        , IBaseServiceCrudLogic<TDomainEntity, int>
        where TDomainEntity : class
        where TRepositoryEntity : class
    {
        private readonly IBaseRepositoryCrud<TRepositoryEntity, int> _baseRepositoryCrud;

        public BaseServiceCrudLogic(IMapper mapper
            , IBaseRepositoryCrud<TRepositoryEntity, int> baseRepositoryCrud)
            : base(mapper)
        {
            _baseRepositoryCrud = baseRepositoryCrud;
        }


        protected TRepositoryEntity GetValidRepositoryEntityFormDomainEntity(TDomainEntity domainEntity)
        {
            return GetRepositoryEntityFromDomainEntity(domainEntity);
        }

        protected virtual void SpecificEntityAddOperations(TRepositoryEntity repositoryEntity, TDomainEntity domainEntity)
        {

        }

        public TDomainEntity GetById(int entityId)
        {
             return GetDomainEntityFromRepositoryEntity(_baseRepositoryCrud.GetById(entityId));
        }

        public List<TDomainEntity> FindBy(Expression<Func<TRepositoryEntity, bool>> predicate)
        {
            return GetDomainEntitiesFromRepositoryEntities(_baseRepositoryCrud.FindBy(predicate));
        }

        public IEnumerable<TDomainEntity> GetAll()
        {
            return GetDomainEntitiesFromRepositoryEntities(_baseRepositoryCrud.GetAll());
        }
    }
}
