using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace BIMFM.EntityFramework.Repositories
{
    public abstract class BIMFMRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<BIMFMDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected BIMFMRepositoryBase(IDbContextProvider<BIMFMDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class BIMFMRepositoryBase<TEntity> : BIMFMRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected BIMFMRepositoryBase(IDbContextProvider<BIMFMDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
