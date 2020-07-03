// Creator: 程邵磊
// CreateTime: 2020/03/18

using ZLYY.Framework.Data.Entity;
using ZLYY.Framework.Data.Repositories;

namespace Admin.EntityFrameworkCore
{
    public interface IAppRepository<TEntity> : IRepository<TEntity, AppDbContext> where TEntity : IEntity
    {
    }
}