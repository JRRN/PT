using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Domain.Logic.Services.Base
{
    public class BaseServiceLogic<TDomainEntity, TRepositoryEntity>
        where TDomainEntity : class
        where TRepositoryEntity : class
    {
        public readonly IMapper Mapper;

        public BaseServiceLogic(IMapper mapper)
        {
            Mapper = mapper;
        }

        protected TRepositoryEntity GetRepositoryEntityFromDomainEntity(TDomainEntity domainEntity)
        {
            return Mapper.Map<TRepositoryEntity>(domainEntity);
        }

        protected t1 GetRepositoryEntityFromDomainEntity<t1, t2>(t2 domainEntity)
        {
            return Mapper.Map<t1>(domainEntity);
        }

        protected TDomainEntity GetDomainEntityFromRepositoryEntity(TRepositoryEntity repositoryEntity)
        {
            return Mapper.Map<TDomainEntity>(repositoryEntity);
        }

        protected IEnumerable<TDomainEntity> GetDomainEntitiesFromRepositoryEntities(IEnumerable<TRepositoryEntity> repositoryEntities)
        {
            return repositoryEntities.Select(GetDomainEntityFromRepositoryEntity).ToList();
        }

        protected List<TDomainEntity> GetDomainEntitiesFromRepositoryEntities(IQueryable<TRepositoryEntity> repositoryEntities)
        {
            return repositoryEntities.Select(GetDomainEntityFromRepositoryEntity).ToList();
        }
    }
}
