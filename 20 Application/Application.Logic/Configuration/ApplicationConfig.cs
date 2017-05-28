using Application.Configuration;
using Domain.Configuration;
using Domain.Logic.Configuration;
using Domain.Logic.Services.Client;
using Domain.Logic.Services.Polices;
using Domain.Services.Client;
using Domain.Services.Polices;
using Microsoft.Practices.Unity;

namespace Application.Logic.Configuration
{
    public class ApplicationConfig : IApplicationConfig
    {
        public void Configure(IUnityContainer container)
        {
            RegisterDomain(container);
            ConfigureDomain(container);
        }
        private static void RegisterDomain(IUnityContainer container)
        {
            container.RegisterType<IDomainConfig, DomainConfig>();

            container.RegisterType<IClientLogic, ClientLogic>();
            container.RegisterType<IPoliceLogic, PoliceLogic>();

        }
        private static void ConfigureDomain(IUnityContainer container)
        {
            IDomainConfig domainConfig = container.Resolve<IDomainConfig>();
            domainConfig.Configure(container);
        }
    }
}