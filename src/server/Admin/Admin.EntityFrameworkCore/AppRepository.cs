// Creator: 程邵磊
// CreateTime: 2020/03/18

using ZLYY.Framework.Data.Entity;
using ZLYY.Framework.Data.Repositories;

namespace Admin.EntityFrameworkCore
{
    public class AppRepository<TEntity> : Repository<TEntity, AppDbContext>, IAppRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        public AppRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}