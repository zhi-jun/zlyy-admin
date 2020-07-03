// Creator: 程邵磊
// CreateTime: 2020/03/31

using System.Security.Claims;

namespace ZLYY.Framework.Session
{
    public interface IPrincipalAccessor
    {
        ClaimsPrincipal Principal { get; }
    }
}