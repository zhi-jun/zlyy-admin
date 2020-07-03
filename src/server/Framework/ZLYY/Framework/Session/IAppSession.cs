// Creator: 程邵磊
// CreateTime: 2020/03/18

using System;
using ZLYY.Framework.Data.MultiTenant;

namespace ZLYY.Framework.Session
{
    public interface IAppSession
    {
        Guid? UserId { get; }

        int? TenantId { get;}

        MultiTenancySides MultiTenancySides { get; }
    }
}