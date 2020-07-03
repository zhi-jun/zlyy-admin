// Creator: 程邵磊
// CreateTime: 2020/03/18

using Admin.EntityFrameworkCore;
using ZLYY.Framework.Data.Entity;
using ZLYY.Framework.Service;

namespace Admin.Application
{
    public class AppService<TEntity> : AppService<TEntity, AppDbContext, IAppRepository<TEntity>>, IAppService<TEntity>
        where TEntity : IEntity
    {
        public AppService(IAppRepository<TEntity> repository) : base(repository)
        {
        }
    }
}