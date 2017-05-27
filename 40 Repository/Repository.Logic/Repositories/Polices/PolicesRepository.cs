using System.Collections.Generic;
using Repository.Logic.Repositories.Base;
using Repository.Repositories.Base;
using Repository.Repositories.Polices;

namespace Repository.Logic.Repositories.Polices
{
    public class PolicesRepository : BaseReadRepository<AxaAltranEntities,Model.Polices, int>, IPolicesRepository
    {
        public PolicesRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}