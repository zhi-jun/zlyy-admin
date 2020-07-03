using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZLYY.Framework.Data.Entity;

namespace Admin.Domain.RolePermission
{
    [Table("Role_Permission")]
    public class RolePermissionEntity : FullAuditedEntity
    {
        /// <summary>
        /// 角色
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// 权限编码
        /// </summary>
        [StringLength(SingleLineContentMaxLength)]
        public string PermissionCode { get; set; }
    }
}
