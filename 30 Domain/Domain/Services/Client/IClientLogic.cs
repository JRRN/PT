using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Configuration;
using Domain.Services.Base;

namespace Domain.Services.Client
{
    public interface IClientLogic : IBaseServiceReadLogic<Domain.Model.Client, int>
    {
        Model.Client FindByName(string name);
    }
}