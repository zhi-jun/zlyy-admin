using AutoMapper.Configuration.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ZLYY.Framework;
using ZLYY.Framework.Service;
using ZLYY.Utils.Extensions;

namespace Admin.Domain.UserEntity
{
    public partial class UserEntity
    {
        /// <summary>
        /// 关联角色
        /// </summary>
        [Ignore]
        [NotMapped]
        public List<OptionResultModel> Roles { get; set; }

        /// <summary>
        /// 用户类型名称
        /// </summary>
        [Ignore]
        [NotMapped]
        public string TypeName => Type.ToDescription();

        /// <summary>
        /// 用户检测
        /// </summary>
        public IResultModel Check()
        {
            if (IsDeleted)
                return ResultModel.Failed("用户不存在");

            if (Status == UserStatus.Register)
                return ResultModel.Failed("用户未激活");

            if (Status == UserStatus.Disabled)
                return ResultModel.Failed("用户已禁用，请联系管理员");

            return ResultModel.Success();
        }
    }
}
