using Domain.Model;
using Repository.Logic.Repositories.Base;
using Repository.Repositories.Clientes;

namespace Repository.Logic.Repositories.Clientes
{
    public class ClientesRepository : BaseRepositoryCrud<Cliente, int>, IClientesRepository
    {
        public ClientesRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}