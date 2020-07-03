// Creator: 程邵磊
// CreateTime: 2020/03/26

namespace ZLYY.Framework.Data.MultiTenant
{
    public interface IMayHaveTenant
    {
        int? TenantId { get; set; }
    }
}