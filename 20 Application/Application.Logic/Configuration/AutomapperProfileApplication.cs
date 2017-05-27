using System.Collections.Generic;
using Application.Configuration;
using CrossCutting.Automapper;
using Domain.Configuration;

namespace Application.Logic.Configuration
{
    public class AutomapperProfileApplication : IAutomapperProfileApplication
    {
        private readonly List<IAutomapperProfileContainer> _profiles = new List<IAutomapperProfileContainer>();
        public AutomapperProfileApplication(IAutoMapperDomainContainer domainProfile)
        {
            _profiles.Add(domainProfile);
        }
        public List<IAutomapperProfileContainer> GetProfiles()
        {
            return _profiles;
        }
    }
}
