using System.ComponentModel;

namespace Admin.Domain.UserEntity
{
    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// 注册
        /// </summary>
        [Description("注册")]
        Register = 1,
        /// <summary>
        /// 激活
        /// </summary>
        [Description("激活")]
        Active = 2,
        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        Disabled = 3
    }
}
