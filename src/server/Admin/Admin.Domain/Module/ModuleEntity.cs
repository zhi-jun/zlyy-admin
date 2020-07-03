using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZLYY.Framework.Data.Entity;

namespace Admin.Domain.Module
{
    /// <summary>
    /// 模块
    /// </summary>
    [Table("Module")]
    public partial class ModuleEntity : FullAuditedEntity
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(ShortContentMaxLength)]
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Required]
        [StringLength(ShortContentMaxLength)]
        public string Code { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [StringLength(ShortContentMaxLength)]
        public string Icon { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [StringLength(ShortContentMaxLength)]
        public string Version { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(ShortContentMaxLength)]
        public string Remarks { get; set; }

        /// <summary>
        /// 接口请求数量
        /// </summary>
        public long ApiRequestCount { get; set; }
    }
}
