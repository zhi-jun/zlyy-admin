using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.Application.UserService.ViewModels
{
    /// <summary>
    /// 用户角色绑定模型
    /// </summary>
    public class UserRoleBindModel
    {
        [Required(ErrorMessage = "请选择用户")]
        public Guid UserId { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        [Required(ErrorMessage = "请选择角色")]
        public Guid RoleId { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Checked { get; set; }
    }
}
