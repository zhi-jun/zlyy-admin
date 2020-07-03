using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ZLYY.Components.Swagger
{
    public static class SwaggerExtensions
    {
        public static string Version;

        /// <summary>
        /// 添加Swagger
        /// </summary>
        /// <param name="services"></param>
        /// <param name="version">版本号</param>
        /// <param name="title">标题</param>
        /// <param name="description">内容</param>
        /// <param name="xmlNames">xml文件名</param>
        public static IServiceCollection AddSwagger(this IServiceCollection services,
                string version, string title, string description, params string[] xmlNames)
        {
            if (string.IsNullOrEmpty(version))
                throw new Exception("SwaggerUI 缺少版本号");

            if (xmlNames == null)
                throw new Exception("SwaggerUI 缺少XML描述文件");

            Version = version;

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Version, new OpenApiInfo
                {
                    Title = $"{title} {Version}",
                    Description = description
                });

                c.DocInclusionPredicate((docName, apiDescription) =>
                {
                    apiDescription.TryGetMethodInfo(out MethodInfo mi);
                    var attr = mi.GetCustomAttribute<HiddenApiAttribute>();
                    return attr == null;
                });

                //c.OperationFilter<AddHeaderOperationFilter>("token", "", false);

                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Name = "token",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });

                foreach (var xml in xmlNames)
                {
                    var xmlApi = Path.Combine(ApplicationEnvironment.ApplicationBasePath, xml);
                    c.IncludeXmlComments(xmlApi, true);
                }
            });
            return services;
        }

        /// <summary>
        /// 初始化Swagger
        /// </summary>
        public static IApplicationBuilder UseSwaggerPro(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"swagger/{Version}/swagger.json", Version);

#if DEBUG
                c.RoutePrefix = "";
#endif

#if RELEASE
                c.RoutePrefix = "api";
#endif

            });
            return app;
        }

    }
}
