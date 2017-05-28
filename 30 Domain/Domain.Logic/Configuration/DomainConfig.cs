

using Domain.Configuration;
using Microsoft.Practices.Unity;
using Repository;
using Repository.Logic;
using Repository.Logic.Repositories.Clientes;
using Repository.Logic.Repositories.Polices;
using Repository.Repositories.Clientes;
using Repository.Repositories.Polices;

namespace Domain.Logic.Configuration
{
    public class DomainConfig : IDomainConfig
    {
        public void Configure(IUnityContainer container)
        {
            container.RegisterType<IAutoMapperDomainContainer, AutoMapperDomainContainer>();

            RegisterRepository(container);

        }

        private void RegisterRepository(IUnityContainer container)
        {
            var unitOfWorkName = typeof(AxaAltranEntities).Name;

            container.RegisterType<IUnitOfWork, AxaAltranEntities>(unitOfWorkName);

            container.RegisterType<IClientesRepository , ClientesRepository>
                (new InjectionConstructor(new ResolvedParameter<IUnitOfWork>(unitOfWorkName)));

            container.RegisterType<IPolicesRepository, PolicesRepository>
                (new InjectionConstructor(new ResolvedParameter<IUnitOfWork>(unitOfWorkName)));

        }
    }
}