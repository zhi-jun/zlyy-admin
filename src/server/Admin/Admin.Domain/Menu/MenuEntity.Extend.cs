using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;
using ZLYY.Utils.Extensions;

namespace Admin.Domain.Menu
{
    public partial class MenuEntity
    {
        /// <summary>
        /// 父节点名称
        /// </summary>
        [Ignore]
        [StringLength(SingleLineContentMaxLength)]
        public string ParentName { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        [Ignore]
        [StringLength(SingleLineContentMaxLength)]
        public string TypeName => Type.ToDescription();

        /// <summary>
        /// 打开方式名称
        /// </summary>
        [Ignore]
        [StringLength(SingleLineContentMaxLength)]
        public string TargetName => Target.ToDescription();
    }
}
