using System.Collections.Generic;
using Application.Services.Base;

namespace Application.Services.Polices
{
    public interface IPoliceApplication : IBaseReadApplication<Domain.Model.Polices, int>
    {
        IEnumerable<Domain.Model.Polices> GetPoliceByName(string name);
        IEnumerable<Domain.Model.Polices> GetAllPolices();
    }
}