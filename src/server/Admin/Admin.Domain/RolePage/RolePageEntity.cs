using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZLYY.Framework.Data.Entity;

namespace Admin.Domain.RolePage
{
    /// <summary>
    /// 角色绑定的页面
    /// </summary>
    [Table("Role_Page")]
    public class RolePageEntity : FullAuditedEntity
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// 页面编码(对应前端路由名称)
        /// </summary>
        [StringLength(SingleLineContentMaxLength)]
        public string PageCode { get; set; }
    }
}
