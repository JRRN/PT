using System.Collections.Generic;
using Domain.Model;

namespace Application.Services.ClientWrapper
{
    public interface IClientWrapperApplication
    {
        ClientsWrapper GetAllClientsWrapper();

    }
}
