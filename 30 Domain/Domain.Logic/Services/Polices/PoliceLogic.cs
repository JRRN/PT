using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Domain.Logic.Services.Base;
using Domain.Services.Base;
using Domain.Services.Polices;
using Repository.Repositories.Polices;

namespace Domain.Logic.Services.Polices
{
    public class PoliceLogic :  BaseServiceLogic<Domain.Model.Polices, Repository.Model.Polices>, IPoliceLogic
    {
        private readonly IPolicesRepository _policeRepository;
        public PoliceLogic(IMapper mapper, IPolicesRepository policeRepository) : base(mapper)
        {
            _policeRepository = policeRepository;
        }


        public Model.Polices GetById(int entityId)
        {
            return GetDomainEntityFromRepositoryEntity(_policeRepository.GetById(entityId));
        }

        public IEnumerable<Model.Polices> GetAll()
        {
            return GetDomainEntitiesFromRepositoryEntities(_policeRepository.GetAll());
        }

        public List<Model.Polices> FindByName(string objectId)
        {
            Expression<Func<Repository.Model.Polices, bool>> repositoryPredicate = polices => polices.ObjetId.Equals(objectId);
            return FindBy(repositoryPredicate);
        }

        public List<Model.Polices> FindBy(Expression<Func<Repository.Model.Polices, bool>> predicate)
        {
            return GetDomainEntitiesFromRepositoryEntities(_policeRepository.FindBy(predicate));
        }
    }
}