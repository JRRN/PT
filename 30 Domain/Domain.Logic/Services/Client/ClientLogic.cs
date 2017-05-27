using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Domain.Logic.Services.Base;
using Domain.Services.Base;
using Domain.Services.Client;
using Repository.Repositories.Clientes;

namespace Domain.Logic.Services.Client
{
    public class ClientLogic : BaseServiceLogic<Domain.Model.Client, Repository.Model.Clients>, IClientLogic
    {
        private readonly IClientesRepository _clientesRepository;


        public ClientLogic(IMapper mapper, IClientesRepository clientesRepository) : base(mapper)
        {
            _clientesRepository = clientesRepository;
        }

        public Model.Client GetById(int entityId)
        {
            return GetDomainEntityFromRepositoryEntity(_clientesRepository.GetById(entityId));
        }

        public Model.Client FindByName(string name)
        {
            Expression<Func<Repository.Model.Clients, bool>> repositoryPredicate = clients => clients.Name.Equals(name);
            return FindBy(repositoryPredicate).FirstOrDefault();
        }

        public List<Model.Client> FindBy(Expression<Func<Repository.Model.Clients, bool>> predicate)
        {
            return GetDomainEntitiesFromRepositoryEntities(_clientesRepository.FindBy(predicate));
        }

        public IEnumerable<Model.Client> GetAll()
        {
            return GetDomainEntitiesFromRepositoryEntities(_clientesRepository.GetAll());
        }
    }
}