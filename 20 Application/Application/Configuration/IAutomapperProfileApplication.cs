using System.Collections.Generic;
using CrossCutting.Automapper;

namespace Application.Configuration
{
    public interface IAutomapperProfileApplication
    {
        List<IAutomapperProfileContainer> GetProfiles();
    }
}
