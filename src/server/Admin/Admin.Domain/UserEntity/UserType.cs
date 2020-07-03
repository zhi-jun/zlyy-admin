using System.ComponentModel;

namespace Admin.Domain.UserEntity
{
    /// <summary>
    /// 用户类型
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// 管理员
        /// </summary>
        [Description("管理员")]
        Admin,
        /// <summary>
        /// 普通用户
        /// </summary>
        [Description("普通用户")]
        Nomal
    }
}
