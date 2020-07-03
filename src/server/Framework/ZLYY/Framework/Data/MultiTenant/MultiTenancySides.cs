// Creator: 程邵磊
// CreateTime: 2020/03/22

using System;

namespace ZLYY.Framework.Data.MultiTenant
{
    [Flags]
    public enum MultiTenancySides
    {
        Tenant = 1,
        Host = 2
    }
}