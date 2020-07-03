using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZLYY.Framework.Data.Entity;

namespace Admin.Domain.Menu
{
    /// <summary>
    /// 菜单
    /// </summary>
    [Table("Menu")]
    public partial class MenuEntity : FullAuditedEntity
    {
        /// <summary>
        /// 所属模块
        /// </summary>
        [StringLength(ShortContentMaxLength)]
        public string ModuleCode { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public MenuType Type { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public Guid ParentId { get; set; } = Guid.Empty;

        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(ShortContentMaxLength)]
        public string Name { get; set; }

        /// <summary>
        /// 路由名称(对应路由菜单的菜单编码)
        /// </summary>
        [StringLength(ShortContentMaxLength)]
        public string RouteName { get; set; }

        /// <summary>
        /// 路由参数
        /// </summary>
        [StringLength(MultiLineContentMaxLength)]
        public string RouteParams { get; set; }

        /// <summary>
        /// 路由参数
        /// </summary>
        [StringLength(MultiLineContentMaxLength)]
        public string RouteQuery { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        [StringLength(SingleLineContentMaxLength)]
        public string Url { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [StringLength(ShortContentMaxLength)]
        public string Icon { get; set; }

        /// <summary>
        /// 图标颜色
        /// </summary>
        [StringLength(ShortContentMaxLength)]
        public string IconColor { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Show { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 打开方式
        /// </summary>
        public MenuTarget Target { get; set; }

        /// <summary>
        /// 对话框宽度
        /// </summary>
        [StringLength(ShortContentMaxLength)]
        public string DialogWidth { get; set; }

        /// <summary>
        /// 对话框高度
        /// </summary>
        [StringLength(ShortContentMaxLength)]
        public string DialogHeight { get; set; }

        /// <summary>
        /// 对话框可全屏
        /// </summary>
        public bool DialogFullscreen { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(ShortContentMaxLength)]
        public string Remarks { get; set; }
    }
}
