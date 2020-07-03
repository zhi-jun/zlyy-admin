// Creator: 程邵磊
// CreateTime: 2020/03/17

using System;

namespace ZLYY.Framework.Data.Entity
{
    public interface IEntity
    {
        Guid Id { get; set; }

        DateTime CreatedTime { get; set; }

        DateTime? ModifyTime { get; set; }
    }
}