// Creator: 程邵磊
// CreateTime: 2020/04/01

using System.ComponentModel.DataAnnotations.Schema;
using ZLYY.Framework.Data.Entity;

namespace ZLYY.Framework.Data.MultiTenant
{
    public abstract class TenantEntity : FullAuditedEntity, IMustHaveTenant
    {
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TenantId { get; set; }
    }
}