using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Model;
using Repository.Logic.Repositories.Base;
using Repository.Repositories.Clientes;
using Repository.Repositories.Base;

namespace Repository.Logic.Repositories.Clientes
{
    public class ClientesRepository : BaseReadRepository<AxaAltranEntities, Client, int>, IClientesRepository
    {
        public ClientesRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Model.Clients GetById(int entityId)
        {
            return Context.Set<Repository.Model.Clients>().Find(entityId);
        }

        public IQueryable<Model.Clients> FindBy(Expression<Func<Model.Clients, bool>> predicate)
        {
            return Context.Set<Repository.Model.Clients>().Where(predicate);
        }

        public IEnumerable<Model.Clients> GetAll()
        {
            return Context.Set<Model.Clients>().ToList();
        }
    }
}