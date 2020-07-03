// Creator: 程邵磊
// CreateTime: 2020/03/17

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZLYY.Framework.Data.Entity;
using ZLYY.Framework.Data.Repositories;

namespace ZLYY.Framework.Service
{
    public interface IAppService<TEntity, TDbContext, out TRepository>
        where TEntity : IEntity
        where TDbContext : DbContext
        where TRepository : IRepository<TEntity, TDbContext>
    {
        TRepository Repository { get; }

        Task<int> Insert(params TEntity[] entities);

        Task<int> Update(params TEntity[] entities);

        Task<int> Update(Expression<Func<TEntity, object>> updateColumns, params TEntity[] entities);

        Task<int> Delete(params Guid[] ids);

        Task<int> Count(Expression<Func<TEntity, bool>> predicate);

        Task<bool> Exist(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> Get(Guid id);

        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TEntity>> selectExpression);

        Task<List<TEntity>> Query<TSortKey>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TSortKey>> sortExpression, bool isDescending = true);

        Task<PagedModel<TEntity>> QueryPage<TSortKey>(Expression<Func<TEntity, bool>> predicate,
            int pageIndex, int pageSize,
            Expression<Func<TEntity, TSortKey>> sortExpression, bool isDescending = true);

        Task<List<TEntity>> QueryByCursor<TSortKey>(Guid cursorId, int topSize,
            Expression<Func<TEntity, TSortKey>> sortExpression, bool isDescending = true);
    }
}