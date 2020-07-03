using System;
using System.ComponentModel.DataAnnotations.Schema;
using ZLYY.Framework.Data.Entity;

namespace Admin.Domain.UserRole
{
    /// <summary>
    /// 用户角色
    /// </summary>
    [Table("User_Role")]
    public class UserRoleEntity : FullAuditedEntity
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        public Guid RoleId { get; set; }
    }
}
