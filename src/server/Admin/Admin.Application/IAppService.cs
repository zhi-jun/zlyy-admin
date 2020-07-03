// Creator: 程邵磊
// CreateTime: 2020/03/18

using Admin.EntityFrameworkCore;
using ZLYY.Framework.Data.Entity;
using ZLYY.Framework.Service;

namespace Admin.Application
{
    public interface IAppService<TEntity> : IAppService<TEntity, AppDbContext, IAppRepository<TEntity>>
        where TEntity : IEntity
    {
    }
}