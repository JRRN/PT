using System.Collections.Generic;
using Application.Services.PolicesWrapper;
using Domain.Model;
using Domain.Services.PolicesWrapper;
using Domain.Services.Rest;

namespace Application.Logic.Services.PolicesWrapper
{
    public class PoliceWrapperApplication : IPoliceWrapperApplication
    {
        private readonly IPoliceWrapperLogic _policeWrapperLogic;

        public PoliceWrapperApplication(IPoliceWrapperLogic policeWrapperLogic)
        {
            _policeWrapperLogic = policeWrapperLogic;
        }

        public Domain.Model.PoliciesWrapper GetAllPolicesWrapper()
        {
            return _policeWrapperLogic.GetAllPolicesWrapper();
        }
    }
}
