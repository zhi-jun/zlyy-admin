// Creator: 程邵磊
// CreateTime: 2020/03/18

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Admin.EntityFrameworkCore
{
    public class DbContextConfiguration : IDbContextConfiguration
    {
        private readonly IConfiguration _configuration;

        public DbContextConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbContextOptions GetDbContextOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            var connectionString = _configuration.GetConnectionString("Default");
            DbContextConfigurer.Configure(optionsBuilder, connectionString);
            return optionsBuilder.Options;
        }
    }
}