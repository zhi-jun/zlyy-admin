// Creator: 程邵磊
// CreateTime: 2020/03/17

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZLYY.Framework.Data.Entity;

namespace ZLYY.Framework.Data.Repositories
{
    public interface IRepository<TEntity, out TDbContent>
        where TEntity : IEntity
        where TDbContent : DbContext
    {
        TDbContent DbContext { get; }

        Task<int> Insert(params TEntity[] entities);

        Task<int> Update(params TEntity[] entities);

        Task<int> Update(Expression<Func<TEntity, object>> updateColumns, params TEntity[] entities);

        Task<int> Delete(params Guid[] ids);

        Task<int> Count(Expression<Func<TEntity, bool>> predicate);

        Task<bool> Exist(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> Get(Guid id);

        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TEntity>> selectExpression);

        IQueryable<TEntity> Query<TSortKey>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TSortKey>> sortExpression, bool isDescending = true);

        IQueryable<TEntity> QueryPage<TSortKey>(Expression<Func<TEntity, bool>> predicate,
            int pageIndex, int pageSize,
            Expression<Func<TEntity, TSortKey>> sortExpression, bool isDescending = true);

        IQueryable<TEntity> QueryByCursor<TSortKey>(Guid startId, int topSize,
            Expression<Func<TEntity, TSortKey>> sortExpression, bool isDescending = true);
    }
}