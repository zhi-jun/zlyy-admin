using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Admin.Application.UserService.ViewModels
{
    public class UpdatePasswordModel
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        [JsonIgnore]
        public Guid UserId { get; set; }

        /// <summary>
        /// 旧密码
        /// </summary>
        [Required(ErrorMessage = "请输入旧密码")]
        public string OldPassword { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        [Required(ErrorMessage = "请输入新密码")]
        public string NewPassword { get; set; }

        /// <summary>
        /// 确认密码
        /// </summary>
        [Required(ErrorMessage = "请输入确认密码")]
        public string ConfirmPassword { get; set; }
    }
}
