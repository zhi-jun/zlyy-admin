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
    public class AppService<TEntity,TDbContext, TRepository> : IAppService<TEntity,TDbContext,TRepository>
        where TEntity : IEntity
        where TDbContext : DbContext
        where TRepository : IRepository<TEntity, TDbContext>
    {
        public virtual TRepository Repository { get; }

        public AppService(TRepository repository)
        {
            Repository = repository;
        }

        public async Task<int> Insert(params TEntity[] entities)
        {
            return await Repository.Insert(entities);
        }

        public async Task<int> Update(params TEntity[] entities)
        {
            return await Repository.Update(entities);
        }

        public async Task<int> Update(Expression<Func<TEntity, object>> updateColumns, params TEntity[] entities)
        {
            return await Repository.Update(updateColumns, entities);
        }

        public async Task<int> Delete(params Guid[] ids)
        {
            return await Repository.Delete(ids);
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> predicate)
        {
            return await Repository.Count(predicate);
        }

        public async Task<bool> Exist(Expression<Func<TEntity, bool>> predicate)
        {
            return await Repository.Exist(predicate);
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await Repository.Get(id);
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await Repository.Get(predicate);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return await Repository.Query(predicate).ToListAsync();
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TEntity>> selectExpression)
        {
            return await Repository.Query(predicate, selectExpression).ToListAsync();
        }

        public async Task<List<TEntity>> Query<TSortKey>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TSortKey>> sortExpression, bool isDescending = true)
        {
            return await Repository.Query(predicate, sortExpression, isDescending).ToListAsync();
        }

        public async Task<PagedModel<TEntity>> QueryPage<TSortKey>(Expression<Func<TEntity, bool>> predicate,
            int pageIndex, int pageSize, Expression<Func<TEntity, TSortKey>> sortExpression, bool isDescending = true)
        {
            var totalCount = await Repository.Count(predicate);
            var pageCount = (int) Math.Ceiling((decimal) totalCount / pageSize);
            var data = await Repository.QueryPage(predicate, pageIndex, pageSize, sortExpression, isDescending)
                .ToListAsync();
            return new PagedModel<TEntity>()
            {
                Data = data,
                DataCount = totalCount,
                PageCount = pageCount,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }

        public async Task<List<TEntity>> QueryByCursor<TSortKey>(Guid cursor, int topSize,
            Expression<Func<TEntity, TSortKey>> sortExpression, bool isDescending = true)
        {
            return await Repository.QueryByCursor(cursor, topSize, sortExpression, isDescending).ToListAsync();
        }
    }
}