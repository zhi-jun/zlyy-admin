using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZLYY.Framework.Data.Entity;
using ZLYY.Framework.Data.MultiTenant;

namespace Admin.Domain.UserEntity
{
    /// <summary>
    /// 用户
    /// </summary>
    [Table("User")]
    public partial class UserEntity : FullAuditedEntity, IMayHaveTenant, ISoftDelete
    {
        /// <summary>
        /// 租户编号
        /// </summary>
        public int? TenantId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public UserType Type { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(ShortContentMaxLength)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [StringLength(ShortContentMaxLength)]
        public string Password { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(SingleLineContentMaxLength)]
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [StringLength(ShortContentMaxLength)]
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// 邮箱
        /// </summary>
        [StringLength(ShortContentMaxLength)]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 状态
        /// </summary>
        public UserStatus Status { get; set; }

        /// <summary>
        /// 是否锁定，锁定后不允许在用户管理中修改
        /// </summary>
        public bool IsLock { get; set; }

        /// <summary>
        /// 注销时间
        /// </summary>
        public DateTime ClosedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 注销人
        /// </summary>
        public Guid ClosedBy { get; set; } = Guid.Empty;

        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
