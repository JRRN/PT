using System.Data.Entity.Infrastructure;
using Repository.Repositories.Base;

namespace Repository.Repositories.Polices
{
    public interface IPolicesRepository : IBaseReadRepository<Model.Polices, int>
    {
        
    }
}