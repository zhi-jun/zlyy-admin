// Creator: 程邵磊
// CreateTime: 2020/04/01

namespace ZLYY.Framework.Data.EntityFramework
{
    public abstract class DbSeederBase<TDbContext> : IDbSeeder
    {
        protected readonly TDbContext DbContext;

        protected DbSeederBase(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract void Seed();
    }
}