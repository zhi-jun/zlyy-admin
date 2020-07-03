// Creator: 程邵磊
// CreateTime: 2020/03/31

using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace ZLYY.Framework.Session
{
    public class PrincipalAccessor : IPrincipalAccessor
    {
        public ClaimsPrincipal Principal => _httpContextAccessor.HttpContext?.User ?? Thread.CurrentPrincipal as ClaimsPrincipal;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public PrincipalAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}