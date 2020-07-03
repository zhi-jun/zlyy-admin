// Creator: 程邵磊
// CreateTime: 2020/03/31

using System.Security.Claims;

namespace ZLYY.Framework.Authentication.Token
{
    public class AppClaimTypes
    {
        public static string UserId => ClaimTypes.NameIdentifier;
        public static string TenantId => "https://www.Admin.com/identity/claims/tenantId";
    }
}