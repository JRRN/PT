namespace Repository.Repositories.Base
{
    public interface IBaseRepositoryCrud<TEntity, TEntityKey> : 
        IBaseReadRepository<TEntity, TEntityKey> 
        where TEntity : class
    {

    }
}