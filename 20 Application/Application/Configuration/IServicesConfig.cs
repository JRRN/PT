using Microsoft.Practices.Unity;

namespace Application.Configuration
{
    public interface IServicesConfig
    {
        void Configure(IUnityContainer container);
    }
}
