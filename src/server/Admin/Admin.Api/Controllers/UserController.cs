using System;
using System.Threading.Tasks;
using Admin.Api.Core;
using Admin.Application.UserService.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Admin.Application.Application.UserService;
using ZLYY.Framework;

namespace Admin.Api.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    [ApiController]
    public class UserController : ControllerAbstract
    {
        private readonly ILoginInfo _loginInfo;
        private readonly IUserService _userService;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="loginInfo"></param>
        public UserController(IUserService userService, ILoginInfo loginInfo)
        {
            _userService = userService;
            _loginInfo = loginInfo;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public Task<IResultModel> Query([FromQuery] UserQueryModel model)
        {
            return _userService.Query(model);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public Task<IResultModel<Guid>> Add(UserAddModel model)
        {
            return _userService.Add(model);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<IResultModel> Update(UserUpdateModel model)
        {
            return _userService.Update(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public Task<IResultModel> Delete([BindRequired] Guid id)
        {
            return _userService.Delete(id);
        }
        /// <summary>
        /// 绑定角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<IResultModel> BindRole(UserRoleBindModel model)
        {
            return _userService.BindRole(model);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Common]
        public Task<IResultModel> UpdatePassword(UpdatePasswordModel model)
        {
            model.UserId = _loginInfo.UserId;
            return _userService.UpdatePassword(model);
        }
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<IResultModel> ResetPassword([BindRequired] Guid id)
        {
            return _userService.ResetPassword(id);
        }
        /// <summary>
        /// 激活用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<IResultModel> Active([BindRequired] Guid id)
        {
            return _userService.Active(id);
        }
    }
}
