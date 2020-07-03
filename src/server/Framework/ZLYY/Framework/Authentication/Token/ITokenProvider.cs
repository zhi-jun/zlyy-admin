// Creator: 程邵磊
// CreateTime: 2020/03/27

using System.Security.Claims;

namespace ZLYY.Framework.Authentication.Token
{
    public interface ITokenProvider
    {
        string GetToken(Claim[] claims);
    }
}