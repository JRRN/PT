

using Domain.Configuration;
using Microsoft.Practices.Unity;
using Repository;
using Repository.Logic;
using Repository.Logic.Repositories.Clientes;
using Repository.Logic.Repositories.Proveedores;
using Repository.Repositories.Clientes;
using Repository.Repositories.Proveedores;

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
            var UnitOfWorkName = typeof(AxaAltranEntities).Name;

            container.RegisterType<IUnitOfWork, AxaAltranEntities>(UnitOfWorkName);

            container.RegisterType<IClientesRepository , ClientesRepository>
                (new InjectionConstructor(new ResolvedParameter<IUnitOfWork>(UnitOfWorkName)));

            container.RegisterType<IProveedoresRepository, ProveedoresRepository>
                (new InjectionConstructor(new ResolvedParameter<IUnitOfWork>(UnitOfWorkName)));

        }
    }
}