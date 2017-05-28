using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Domain.Services.ClientWrapper;
using Domain.Services.Rest;
using Newtonsoft.Json;

namespace Domain.Logic.Services.ClientWrapper
{
    public class ClientWrapperLogic : IClientWrapperLogic
    {
        private readonly IRestServiceLogic _restServiceLogic;

        public ClientWrapperLogic(IRestServiceLogic restServiceLogic)
        {
            _restServiceLogic = restServiceLogic;
        }

        public ClientsWrapper GetAllClientsWrapper()
        {
            var url = "http://www.mocky.io";
            var action = "v2/5808862710000087232b75ac";
            var clients = _restServiceLogic.GetWrapperData<Model.ClientWrapper>(url, action);
            var clientsWrapper = JsonConvert.DeserializeObject<ClientsWrapper>(clients);
            return clientsWrapper;
        }

        public Model.ClientWrapper GetUserWrapperById(string id)
        {
            var clientsWrapper = GetAllClientsWrapper();
            return clientsWrapper.Clients.FirstOrDefault(client => client.id.Equals(id));
        }

        public Model.ClientWrapper GetUserWrapperByUserName(string username)
        {
            var clientsWrapper = GetAllClientsWrapper();
            return clientsWrapper.Clients.FirstOrDefault(client => client.name.Equals(username));
        }

    }
}
