using System;
using System.IO;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using ZLYY.Web;
using ZLYY.Components.Swagger;
using ZLYY;

namespace Admin.Api
{
    /// <summary>
    /// Setup
    /// </summary>
    public class Startup
    {
        IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAppFrameworkConfiguration(_configuration);

            services.AddSwagger("v1.0",
                "后台管理系统",
                $"构建时间: {File.GetLastWriteTime(GetType().Assembly.Location):yyyy-MM-dd HH:mm} <br/> " +
                $"启动时间: {DateTime.Now.ToLocalTime():yyyy-MM-dd HH:mm}",
                "Admin.Api.xml");

            services.AddControllers();
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAppFrameworkConfiguration();
            app.UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure Autofac container
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var booter = AppFraweworkBooter.Create(builder);
            booter.Register();
            builder.RegisterBuildCallback(booter.Build);
        }
    }
}
