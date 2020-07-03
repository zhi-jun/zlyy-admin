using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZLYY.Framework.Data.Entity;

namespace Admin.Domain.Role
{
    /// <summary>
    /// 角色
    /// </summary>
    [Table("Role")]
    public partial class RoleEntity : CreationAuditedEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(ShortContentMaxLength)]
        public string Name { get; set; }

        /// <summary>
        /// 是否是指定的角色，如果是其它模块指定的，不允许删除修改
        /// </summary>
        public bool IsSpecified { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(SingleLineContentMaxLength)]
        public string Remarks { get; set; }
    }
}
