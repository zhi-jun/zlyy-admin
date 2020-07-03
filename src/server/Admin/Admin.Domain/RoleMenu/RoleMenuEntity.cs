using System;
using System.ComponentModel.DataAnnotations.Schema;
using ZLYY.Framework.Data.Entity;

namespace Admin.Domain.RoleMenu
{
    /// <summary>
    /// 角色菜单
    /// </summary>
    [Table("Role_Menu")]
    public partial class RoleMenuEntity : FullAuditedEntity
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// 菜单编号
        /// </summary>
        public Guid MenuId { get; set; }
    }
}
