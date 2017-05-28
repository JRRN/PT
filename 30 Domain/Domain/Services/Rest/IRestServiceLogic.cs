using System.Collections.Generic;

namespace Domain.Services.Rest
{
    public interface IRestServiceLogic
    {
        string GetWrapperData<T>(string url, string action);
    }
}