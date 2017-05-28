using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Domain.Services.PolicesWrapper;
using Domain.Services.Rest;
using Newtonsoft.Json;

namespace Domain.Logic.Services.PolicesWrapper
{
    public class PoliceWrapperLogic : IPoliceWrapperLogic
    {
        private readonly IRestServiceLogic _restServiceLogic;

        public PoliceWrapperLogic(IRestServiceLogic restServiceLogic)
        {
            _restServiceLogic = restServiceLogic;
        }

        public Model.PoliciesWrapper GetAllPolicesWrapper()
        {
            var url = "http://www.mocky.io";
            var action = "v2/580891a4100000e8242b75c5";
            var polices =  _restServiceLogic.GetWrapperData<PolicieWrapper>(url, action);
            var policesWrapper = JsonConvert.DeserializeObject<Model.PoliciesWrapper>(polices);
            return policesWrapper;
        }

    }
}
