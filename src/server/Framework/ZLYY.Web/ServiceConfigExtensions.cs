// Creator: 程邵磊
// CreateTime: 2020/03/16

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ZLYY.Components.Jwt;
using ZLYY.Web.Filter;
using ZLYY.Web.Router;
using Microsoft.Extensions.Configuration;

namespace ZLYY.Web
{
    public static class ServiceConfigExtensions
    {
        public static void AddAppFrameworkConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddMvc(option => { option.Filters.Add<ModelStateActionFilter>(); })
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm";
                    opt.UseCamelCasing(true);
                });
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            services.AddControllersWithViews(opts => { opts.UseGeneralRoutePrefix("api"); });
            services.AddRouting(opts => opts.LowercaseUrls = true);
            services.AddJwtConfiguration(config);
        }
    }
}