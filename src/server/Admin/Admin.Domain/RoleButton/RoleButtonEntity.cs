using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZLYY.Framework.Data.Entity;

namespace Admin.Domain.RoleButton
{
    /// <summary>
    /// 角色按钮绑定关系
    /// </summary>
    [Table("Role_Button")]
    public class RoleButtonEntity : FullAuditedEntity
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// 页面编码
        /// </summary>
        [StringLength(SingleLineContentMaxLength)]
        public string PageCode { get; set; }

        /// <summary>
        /// 按钮编码
        /// </summary>
        [StringLength(SingleLineContentMaxLength)]
        public string ButtonCode { get; set; }
    }
}
