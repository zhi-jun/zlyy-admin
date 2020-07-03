using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using ZLYY.Components.Logging;
using ZLYY.Framework.Exception;
using Newtonsoft.Json;

namespace ZLYY.Web.Middleware
{
    /// <summary>
    /// 统一错误处理
    /// </summary>
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;

        /// <summary>
        /// DI,注入环境变量
        /// </summary>
        /// <param name="next"></param>
        /// <param name="environment"></param>
        public ErrorHandlerMiddleware(RequestDelegate next, IHostEnvironment environment)
        {
            _next = next;
            _env = environment;
        }
        /// <summary>
        /// 实现Invoke方法
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        /// <summary>
        /// 错误信息处理方法
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var isFriendlyException = ex is AppFriendlyException;
            var errorMsg = isFriendlyException ? ex.Message : $"{ex.Message} \r\n【StackTrace】：{ex.StackTrace}";
            
            //记录日志
            Logging.Error(errorMsg);

            context.Response.StatusCode = isFriendlyException ? (int) HttpStatusCode.OK : (int) HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";


            //返回错误信息
            return context.Response.WriteAsync(JsonConvert.SerializeObject(
                Result.Result.Failed(_env.IsDevelopment() ? errorMsg : ex.Message)
           ));
        }
    }
}
