// Creator: 程邵磊
// CreateTime: 2020/03/17

using System;

namespace ZLYY.Framework.Data.Entity
{
    public abstract class FullAuditedEntity : Entity, IModifyAuditedEntity, ICreationAuditedEntity
    {
        public Guid? ModifyUser { get; set; }
        public Guid CreateUser { get; set; }
    }
}