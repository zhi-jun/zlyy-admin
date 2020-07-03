// Creator: 程邵磊
// CreateTime: 2020/03/16

using System.IO;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NLog.Web;

namespace ZLYY.Web
{
    public static class HostBuilderExtensions
    {
        public static IHost BuildAppCoreFramework(this IHostBuilder hostBuilder)
        {
            return hostBuilder
                .ConfigureAppConfiguration((webhost, builder) =>
                {
                    if (!Directory.Exists("AppConfigs")) return;
                    foreach (var file in Directory.GetFiles("AppConfigs", "*.json"))
                    {
                        builder
                            .AddJsonFile(file)
                            .SetBasePath(webhost.HostingEnvironment.ContentRootPath);
                    }
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseNLog()
                .Build();
        }
    }
}