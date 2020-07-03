// Creator: 程邵磊
// CreateTime: 2020/03/17

using System;
using System.ComponentModel.DataAnnotations;

namespace ZLYY.Framework.Data.Entity
{
    public abstract class Entity : IEntity
    {
        public const int ShortContentMaxLength = 32;
        public const int SingleLineContentMaxLength = 128;
        public const int MultiLineContentMaxLength = 512;

        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime? ModifyTime { get; set; }
    }
}