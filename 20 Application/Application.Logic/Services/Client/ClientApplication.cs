using System.Collections.Generic;
using Application.Services.Client;
using Domain.Services.Client;

namespace Application.Logic.Services.Client
{
    public class ClientApplication : IClientApplication
    {
        private readonly IClientLogic _clientLogic;

        public ClientApplication(IClientLogic clientLogic)
        {
            _clientLogic = clientLogic;
        }

        public Domain.Model.Client GetById(int entityId)
        {
            return _clientLogic.GetById(entityId);
        }

        public IEnumerable<Domain.Model.Client> GetAll()
        {
            return _clientLogic.GetAll();
        }

        public Domain.Model.Client GetByName(string entityName)
        {
            return _clientLogic.FindByName(entityName);
        }
    }
}