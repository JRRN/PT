using System;
using System.Collections.Generic;
using Application.Services.Base;

namespace Application.Services.Client
{
    public interface IClientApplication : IBaseReadApplication<Domain.Model.Client, int>
    {
        Domain.Model.Client GetByName(string entityName);
        IEnumerable<Domain.Model.Client> GetAll();
    }
}