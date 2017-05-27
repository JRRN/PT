using System.Collections.Generic;
using Repository.Repositories.Base;

namespace Repository.Repositories.Clientes
{
    public interface IClientesRepository : IBaseReadRepository<Model.Clients, int>
    {
    }
}