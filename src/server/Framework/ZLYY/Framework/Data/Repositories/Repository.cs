// Creator: 程邵磊
// CreateTime: 2020/03/18

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ZLYY.Framework.Data.Entity;

namespace ZLYY.Framework.Data.Repositories
{
    public class Repository<TEntity, TDbContent> : IRepository<TEntity, TDbContent>
        where TEntity : class, IEntity, new()
        where TDbContent : DbContext
    {
        public TDbContent DbContext { get; }

        protected virtual DbSet<TEntity> Table => DbContext.Set<TEntity>();

        public Repository(TDbContent dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<int> Insert(params TEntity[] entities)
        {
            if (entities == null || entities.Length < 1) return 0;
            foreach (var entity in entities)
            {
                Table.Add(entity);
            }

            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> Update(params TEntity[] entities)
        {
            if (entities == null || entities.Length < 1) return 0;
            foreach (var entity in entities)
            {
                Table.Update(entity);
            }

            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> Update(Expression<Func<TEntity, object>> columns, params TEntity[] entities)
        {
            var updateProperties = columns.Type.GetProperties();
            var entityProperties = typeof(TEntity).GetProperties();
            foreach (var entity in entities)
            {
                var entityEntry = DbContext.Entry(entity);
                foreach (var propertyInfo in entityProperties)
                {
                    if (!updateProperties.Any(o =>
                        o.Name == propertyInfo.Name && o.PropertyType == propertyInfo.PropertyType))
                        continue;
                    entityEntry.Property(propertyInfo.Name).IsModified = false;
                }

                Table.Update(entity);
            }

            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(params Guid[] ids)
        {
            if (ids == null || ids.Length < 1) return 0;
            foreach (var id in ids)
            {
                var entity = GetFromChangeTrackerOrNull(id);
                // ReSharper disable once SuspiciousTypeConversion.Global
                if (entity is ISoftDelete softDelete)
                {
                    softDelete.IsDeleted = true;
                    Table.Update(entity);
                }
                else
                {
                    Table.Remove(entity);
                }
            }

            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.CountAsync(predicate);
        }

        public async Task<bool> Exist(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await Get(o => o.Id == id);
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.SingleOrDefaultAsync(predicate);
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate);
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TEntity>> selectFunc)
        {
            return Table.Where(predicate).Select(selectFunc);
        }

        public IQueryable<TEntity> Query<TSortKey>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TSortKey>> sortExpression, bool isDescending = true)
        {
            return ApplySorting(Table.Where(predicate), sortExpression, isDescending);
        }

        public IQueryable<TEntity> QueryPage<TSortKey>(Expression<Func<TEntity, bool>> predicate, int pageIndex,
            int pageSize,
            Expression<Func<TEntity, TSortKey>> sortExpression, bool isDescending = true)
        {
            return ApplySorting(Table.Where(predicate), sortExpression, isDescending)
                .Skip(pageIndex * pageSize)
                .Take(pageSize);
        }

        public IQueryable<TEntity> QueryByCursor<TSortKey>(Guid startId, int topSize,
            Expression<Func<TEntity, TSortKey>> sortExpression, bool isDescending = true)
        {
            if (topSize == 0) return null;
            var entity = Table.SingleOrDefault(o => o.Id == startId);
            if (entity == null) throw new InvalidOperationException();
            var query = ApplySorting(Table.AsQueryable(), sortExpression, isDescending);
            var index = query.IndexOf(entity);
            if (topSize > 0)
            {
                var totalCount = Table.Count();
                var topIndex = index + topSize;
                if (topIndex >= totalCount)
                    topIndex = totalCount - 1;
                var takeCount = topIndex - index;
                if (takeCount == 0) return null;
                return query.Skip(index + 1).Take(takeCount);
            }
            else
            {
                var bottomIndex = index - topSize;
                if (bottomIndex < 0) bottomIndex = 0;
                var takeCount = index - bottomIndex;
                if (takeCount == 0) return null;
                return query.Skip(bottomIndex + 1).Take(takeCount);
            }
        }

        private TEntity GetFromChangeTrackerOrNull(Guid id)
        {
            var entry = DbContext.ChangeTracker.Entries()
                .FirstOrDefault(
                    ent =>
                        ent.Entity is TEntity entity &&
                        EqualityComparer<Guid>.Default.Equals(id, entity.Id)
                );
            return entry?.Entity as TEntity;
        }

        protected virtual IQueryable<TEntity> ApplySorting<TSortKey>(IQueryable<TEntity> query,
            Expression<Func<TEntity, TSortKey>> sortExpression, bool isDescending = true)
        {
            query = isDescending ? query.OrderByDescending(sortExpression) : query.OrderBy(sortExpression);
            return query;
        }
    }
}