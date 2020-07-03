// Creator: 程邵磊
// CreateTime: 2020/03/22

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Admin.EntityFrameworkCore;

namespace Admin.Migrator
{
    /*Used for migration command only: dotnet ef migrations add {version} --project Admin.Migrator*/
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = AppConfigurations.Configuration.GetConnectionString("Default");
            DbContextConfigurer.Configure(builder, connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}