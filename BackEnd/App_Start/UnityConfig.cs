using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using System;
using Application.Services.Client;
using Application.Logic.Services.Client;
using Application.Services.Polices;
using Application.Logic.Services.Polices;
using Application.Configuration;
using Application.Logic.Configuration;
using AutoMapper;

namespace BackEnd
{
    public static class UnityConfig
    {
        #region Unity Container

        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        private static void RegisterTypes(UnityContainer container)
        {
            RegisterApplicationTypes(container);
            RegisterAutoMapper(container);
            }

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        #endregion


        private static void RegisterApplicationTypes(UnityContainer container)
        {
            container.RegisterType<IApplicationConfig, ApplicationConfig>();

            container.RegisterType<IClientApplication, ClientApplication>();
            container.RegisterType<IPoliceApplication, PoliceApplication>();
        }

        public static void RegisterAutoMapper(IUnityContainer container)
        {
            container.RegisterType<IAutomapperProfileApplication, AutomapperProfileApplication>();

            var automapperProfilesService = container.Resolve<IAutomapperProfileApplication>();

            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                automapperProfilesService.GetProfiles()
                    .ForEach(profileContainer => configuration.AddProfile(profileContainer.GetProfile()));
                configuration.AddProfile(new AutomapperWebAPIProfile());
            });

            container.RegisterInstance<IMapper>(mapperConfiguration.CreateMapper());
        }
    }
}