using System.Collections.Generic;
using CrossCutting.Automapper;

namespace Application.Configuration
{
    public interface IAutomapperProfileService
    {
        List<IAutomapperProfileContainer> GetProfiles();
    }
}
