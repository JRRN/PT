using System.Collections.Generic;
using Domain.Model;

namespace Application.Services.PolicesWrapper
{
    public interface IPoliceWrapperApplication
    {
        Domain.Model.PoliciesWrapper GetAllPolicesWrapper();
    }
}
