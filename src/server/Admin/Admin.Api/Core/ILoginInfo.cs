using Admin.Domain.UserEntity;
using System;
using ZLYY.Framework.Authentication;

namespace Admin.Api.Core
{
    /// <summary>
    /// 登录信息
    /// </summary>
    public interface ILoginInfo
    {
        /// <summary>
        /// 租户编号
        /// </summary>
        Guid? TenantId { get; }

        /// <summary>
        /// 用户编号
        /// </summary>
        Guid UserId { get; }

        /// <summary>
        /// 用户名称
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// 用户类型
        /// </summary>
        UserType UserType { get; }

        /// <summary>
        /// 平台
        /// </summary>
        Platform Platform { get; }

        /// <summary>
        /// 获取当前用户IP(包含IPv和IPv6)
        /// </summary>
        string IP { get; }

        /// <summary>
        /// 获取当前用户IPv4
        /// </summary>
        string IPv4 { get; }

        /// <summary>
        /// 获取当前用户IPv6
        /// </summary>
        string IPv6 { get; }

        /// <summary>
        /// 登录时间戳
        /// </summary>
        long LoginTime { get; }

        /// <summary>
        /// 获取当前用户请求的User-Agent
        /// </summary>
        string UserAgent { get; }
    }
}
