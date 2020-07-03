using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ZLYY.Web;

namespace Admin.Api
{
    /// <summary>
    /// MainProgram
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Run();
        }

        /// <summary>
        /// CreateBuilder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHost CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .BuildAppCoreFramework();
    }
}
