using Admin.Domain.UserEntity;
using ZLYY.Framework.Service;

namespace Admin.Application.UserService.ViewModels
{
    public class UserQueryModel : QueryModel
    {
        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType? Type { get; set; }

        public int Age { get; set; }

        public int AgeTest { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public UserStatus Status { get; set; }
    }
}
