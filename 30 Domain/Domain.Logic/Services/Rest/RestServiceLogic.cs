using System.Collections.Generic;
using Domain.Services.Rest;
using Newtonsoft.Json;
using RestSharp;

namespace Domain.Logic.Services.Rest
{
    public class RestServiceLogic : IRestServiceLogic
    {
        public string GetWrapperData<T>(string url, string action)
        {
            var client = new RestClient(url);
            var request = new RestRequest(action, Method.GET);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            return content;
        }

        private List<T> SerializeJson<T>(string jsonInput)
        {
            return JsonConvert.DeserializeObject<List<T>>(jsonInput);
        }
    }
}