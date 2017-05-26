using Repository.Logic.Repositories.Base;
using Repository.Repositories.Proveedores;

namespace Repository.Logic.Repositories.Proveedores
{
    public class ProveedoresRepository : BaseRepositoryCrud<Logic.Proveedores, int>, IProveedoresRepository
    {
        public ProveedoresRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}