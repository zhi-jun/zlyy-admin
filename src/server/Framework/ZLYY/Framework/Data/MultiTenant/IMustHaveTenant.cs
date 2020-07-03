// Creator: 程邵磊
// CreateTime: 2020/03/17

using System;

namespace ZLYY.Framework.Data.MultiTenant
{
    public interface IMustHaveTenant
    {
        int TenantId { get; set; }
    }
}