using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public Domain.Model.Client FindByName(string userName)
        {
            return _clientLogic.FindByName(userName);
        }
    }
}