// Creator: 程邵磊
// CreateTime: 2020/04/01

using ZLYY.Framework.Data.EntityFramework;

namespace Admin.EntityFrameworkCore.Seed
{
    public class AppDbSeeder : DbSeederBase<AppDbContext>
    {
        public AppDbSeeder(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override void Seed()
        {
            new DefaultAdminSeeder().Create(DbContext);
        }
    }
}