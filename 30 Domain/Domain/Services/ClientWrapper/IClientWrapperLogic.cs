using System.Collections.Generic;
using Domain.Model;

namespace Domain.Services.ClientWrapper
{
    public interface IClientWrapperLogic
    {
        ClientsWrapper GetAllClientsWrapper();
        Model.ClientWrapper GetUserWrapperById(string id);

    }
}
