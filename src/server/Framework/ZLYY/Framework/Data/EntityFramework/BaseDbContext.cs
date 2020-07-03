// Creator: 程邵磊
// CreateTime: 2020/03/17

using System;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ZLYY.Framework.Data.Entity;
using ZLYY.Framework.Data.MultiTenant;
using ZLYY.Framework.Session;
using ZLYY.Utils.Extensions;

namespace ZLYY.Framework.Data.EntityFramework
{
    public abstract class BaseDbContext : DbContext
    {
        private static readonly MethodInfo ConfigureGlobalFiltersMethodInfo = typeof(BaseDbContext).GetMethod(nameof(ConfigureGlobalFilters), BindingFlags.Instance | BindingFlags.NonPublic);

        public IAppSession AbpSession { get; set; }

        protected BaseDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                ConfigureGlobalFiltersMethodInfo
                    .MakeGenericMethod(entityType.ClrType)
                    .Invoke(this, new object[] { modelBuilder, entityType });
            }
        }

        protected void ConfigureGlobalFilters<TEntity>(ModelBuilder modelBuilder, IMutableEntityType entityType)
            where TEntity : class
        {
            if (entityType.BaseType == null && ShouldFilterEntity<TEntity>())
            {
                var filterExpression = CreateFilterExpression<TEntity>();
                if (filterExpression == null) return;
                modelBuilder.Entity<TEntity>().HasQueryFilter(filterExpression);
            }
        }

        private bool ShouldFilterEntity<TEntity>() where TEntity : class
        {
            if (AbpSession == null) return false;

            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                return true;
            }

            if (typeof(IMustHaveTenant).IsAssignableFrom(typeof(TEntity)))
            {
                return true;
            }

            if (typeof(IMayHaveTenant).IsAssignableFrom(typeof(TEntity)))
            {
                return true;
            }

            return false;
        }

        private Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>() where TEntity : class
        {
            var currentId = AbpSession.TenantId;

            Expression<Func<TEntity, bool>> expression = null;

            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                Expression<Func<TEntity, bool>> softDeleteFilter = e => !((ISoftDelete) e).IsDeleted;
                expression = softDeleteFilter;
            }

            if (typeof(IMustHaveTenant).IsAssignableFrom(typeof(TEntity)) && currentId != null)
            {
                Expression<Func<TEntity, bool>> mustHaveTenantFilter =
                    e => ((IMustHaveTenant) e).TenantId == currentId;
                expression = expression == null
                    ? mustHaveTenantFilter
                    : CombineExpressions(expression, mustHaveTenantFilter);
            }
            else if (typeof(IMayHaveTenant).IsAssignableFrom(typeof(TEntity)))
            {
                Expression<Func<TEntity, bool>> mayHaveTenantFilter =
                    e => currentId == null || ((IMustHaveTenant) e).TenantId == currentId;
                expression = expression == null
                    ? mayHaveTenantFilter
                    : CombineExpressions(expression, mayHaveTenantFilter);
            }

            return expression;
        }

        protected virtual Expression<Func<T, bool>> CombineExpressions<T>(Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            return ExpressionCombiner.Combine(expression1, expression2);
        }
    }
}