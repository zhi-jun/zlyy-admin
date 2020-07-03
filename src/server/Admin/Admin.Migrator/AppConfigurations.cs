// Creator: 程邵磊
// CreateTime: 2020/03/22

using Microsoft.Extensions.Configuration;

namespace Admin.Migrator
{
    public static class AppConfigurations
    {
        public static IConfigurationRoot Configuration { get; }

        static AppConfigurations()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
        }
    }
}