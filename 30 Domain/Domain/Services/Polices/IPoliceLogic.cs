using System.Collections.Generic;
using Domain.Services.Base;

namespace Domain.Services.Polices
{
    public interface IPoliceLogic : IBaseServiceReadLogic<Domain.Model.Polices, int>
    {
        List<Model.Polices> FindByName(string name);
    }
}