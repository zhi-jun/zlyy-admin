using Admin.Application.UserService.ViewModels;
using System;
using System.Threading.Tasks;
using ZLYY.Framework;

namespace NetModular.Module.Admin.Application.UserService
{
    /// <summary>
    /// 账户服务
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Query(UserQueryModel model);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        Task<IResultModel<Guid>> Add(UserAddModel model);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Update(UserUpdateModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> Delete(Guid id);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> UpdatePassword(UpdatePasswordModel model);

        /// <summary>
        /// 绑定角色
        /// </summary>
        /// <returns></returns>
        Task<IResultModel> BindRole(UserRoleBindModel model);

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> ResetPassword(Guid id);

        /// <summary>
        /// 查询账户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> Get(Guid id);

        /// <summary>
        /// 手动激活账户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> Active(Guid id);
    }
}
