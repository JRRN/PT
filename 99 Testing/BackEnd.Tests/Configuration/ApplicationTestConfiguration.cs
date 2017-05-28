using System;
using Microsoft.Practices.Unity;
using Application.Configuration;
using Application.Logic.Configuration;
using Application.Logic.Services.ClientWrapper;
using Application.Logic.Services.PolicesWrapper;
using Application.Services.ClientWrapper;
using Application.Services.PolicesWrapper;
using AutoMapper;

namespace BackEnd.Tests.Configuration
{
    public class ApplicationTestConfiguration
    {
        static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            RegisterServiceTypes(container);
            RegisterLayerTypes(container);
            //RegisterAutoMapper(container);
        }

        static void RegisterServiceTypes(IUnityContainer container)
        {
            container.RegisterType<IClientWrapperApplication, ClientWrapperApplication>();
            container.RegisterType<IPoliceWrapperApplication, PoliceWrapperApplication>();
            container.RegisterType<IApplicationConfig, ApplicationConfig>();
        }

        public static void RegisterLayerTypes(IUnityContainer container)
        {
            var servicesConfig = container.Resolve<IApplicationConfig>();
            servicesConfig.Configure(container);
        }
    }
}