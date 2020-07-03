// Creator: 程邵磊
// CreateTime: 2020/03/18

using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using ZLYY.Framework.Authentication.Token;
using ZLYY.Framework.Data.MultiTenant;
using ZLYY.Framework.Dependency;

namespace ZLYY.Framework.Session
{
    public class AppSession : IAppSession, IRequestDependency
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppSession(IHttpContextAccessor httpContextAccessor)
        {
            Console.WriteLine("Create AppSession");
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid? UserId
        {
            get
            {
                if (_httpContextAccessor?.HttpContext == null) return null;
                var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.UserId);
                if (string.IsNullOrEmpty(userIdClaim?.Value))
                {
                    return null;
                }

                if (!Guid.TryParse(userIdClaim.Value, out var userId))
                {
                    return null;
                }

                return userId;
            }
        }

        public int? TenantId
        {
            get
            {
                if (_httpContextAccessor?.HttpContext == null) return null;
                var tenantIdString =
                    _httpContextAccessor.HttpContext.Request.Headers.Keys.FirstOrDefault(o => o == "TenantId");
                if (string.IsNullOrEmpty(tenantIdString)) return null;
                return int.Parse(tenantIdString);
            }
        }

        public MultiTenancySides MultiTenancySides => TenantId == null ? MultiTenancySides.Host : MultiTenancySides.Tenant;
    }
}