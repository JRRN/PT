using System;
using System.Linq;
using Application.Services.ClientWrapper;
using Application.Services.PolicesWrapper;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackEnd.Tests
{
    [TestClass]
    public class UnitTest1
    {
        protected readonly IUnityContainer _unityResolver;
        private readonly IPoliceWrapperApplication _policeWrapperApplication;
        private readonly IClientWrapperApplication _clientWrapperApplication;

        public UnitTest1()
        {
            _unityResolver = Configuration.ApplicationTestConfiguration.GetConfiguredContainer();
            _policeWrapperApplication = _unityResolver.Resolve<IPoliceWrapperApplication>();
            _clientWrapperApplication = _unityResolver.Resolve<IClientWrapperApplication>();
        }

        [TestMethod]
        public void GetAllClientsWrapper()
        {
            var clients = _clientWrapperApplication.GetAllClientsWrapper();

            Assert.IsTrue(clients.Clients.Any());
        }
        [TestMethod]
        public void GetAllPolicesWrapper()
        {
            var polices = _policeWrapperApplication.GetAllPolicesWrapper();

            Assert.IsTrue(polices.Policies.Any());
        }
    }
}
