using Microsoft.Practices.Unity;

namespace Domain.Configuration
{
    public interface IDomainConfig
    {
        void Configure(IUnityContainer container);
    }
}
