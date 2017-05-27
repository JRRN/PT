using Microsoft.Practices.Unity;

namespace Application.Configuration
{
    public interface IApplicationConfig
    {
        void Configure(IUnityContainer container);
    }
}
