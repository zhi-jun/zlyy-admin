// Creator: 程邵磊
// CreateTime: 2020/03/22

using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace Admin.EntityFrameworkCore
{
    public class DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder optionsBuilder, string connectionString)
        {
            optionsBuilder.UseMySql(connectionString, options =>
            {
                options.ServerVersion(new ServerVersion(new Version(8, 0, 19)))
                    .CharSetBehavior(CharSetBehavior.AppendToAllColumns).CharSet(CharSet.Utf8Mb4);
                options.MigrationsAssembly("Admin.Migrator");
            });
        }
    }
}