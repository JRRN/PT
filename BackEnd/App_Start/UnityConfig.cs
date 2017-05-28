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
using CustomAuthorization;
using CustomAuthorization.Logic;

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
            RegisterAuthorizartion(container);
            RegisterLayerTypes(container);
            RegisterAutoMapper(container);
        }

        private static void RegisterAuthorizartion(UnityContainer container)
        {
            container.RegisterType<IAuthorization, Authorization>();
        }

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        #endregion
        public static void RegisterLayerTypes(IUnityContainer container)
        {
            var applicationConfig = container.Resolve<IApplicationConfig>();
            applicationConfig.Configure(container);
        }

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