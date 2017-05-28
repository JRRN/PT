using System.Collections.Generic;
using System.Linq;
using Application.Services.ClientWrapper;
using Domain.Model;
using Domain.Services.ClientWrapper;
using Domain.Services.Rest;

namespace Application.Logic.Services.ClientWrapper
{
    public class ClientWrapperApplication : IClientWrapperApplication
    {
        private readonly IClientWrapperLogic _clientWrapperLogic;

        public ClientWrapperApplication(IClientWrapperLogic clientWrapperLogic)
        {
            _clientWrapperLogic = clientWrapperLogic;
        }

        public Domain.Model.ClientWrapper GetUserWrapperById(string id)
        {
            return _clientWrapperLogic.GetUserWrapperById(id);

        }

        public ClientsWrapper GetAllClientsWrapper()
        {
            var clients = _clientWrapperLogic.GetAllClientsWrapper();
            return clients;
        }
    }
}
