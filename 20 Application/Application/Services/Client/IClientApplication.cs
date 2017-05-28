using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Services.Base;

namespace Application.Services.Client
{
    public interface IClientApplication : IBaseReadApplication<Domain.Model.Client, int>
    {
        IEnumerable<Domain.Model.Client> GetAll();
        Domain.Model.Client FindByName(string userName);
    }
}