// Creator: 程邵磊
// CreateTime: 2020/03/16

using Microsoft.AspNetCore.Builder;
using ZLYY.Components.Swagger;
using ZLYY.Web.Middleware;

namespace ZLYY.Web
{
    public static class ConfigurationExtensions
    {
        public static void UseAppFrameworkConfiguration(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>()
                .UseSwaggerPro();
        }
    }
}