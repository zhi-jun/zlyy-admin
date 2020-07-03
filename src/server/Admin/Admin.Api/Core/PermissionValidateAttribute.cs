using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ZLYY.Utils.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Core
{
    /// <summary>
    /// 权限验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionValidateAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            //排除匿名访问
            if (context.ActionDescriptor.EndpointMetadata.Any(m => m.GetType() == typeof(AllowAnonymousAttribute)))
                return;

            //未登录
            var loginInfo = context.HttpContext.RequestServices.GetService<ILoginInfo>();
            if (loginInfo == null || loginInfo.UserId.IsEmpty())
            {
                context.Result = new ChallengeResult();
                return;
            }

            //排除通用接口
            if (context.ActionDescriptor.EndpointMetadata.Any(m => m.GetType() == typeof(CommonAttribute)))
                return;

            var httpMethod = (HttpMethod)Enum.Parse(typeof(HttpMethod), context.HttpContext.Request.Method);
            var handler = context.HttpContext.RequestServices.GetService<IPermissionValidateHandler>();

            if (!await handler.Validate(context.ActionDescriptor.RouteValues, httpMethod))
            {
                //无权访问
                context.Result = new ForbidResult();
            }
        }
    }
}
