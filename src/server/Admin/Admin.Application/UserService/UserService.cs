using System;
using System.Linq;
using System.Threading.Tasks;
using Admin.Application.UserService.ViewModels;
using Admin.Domain.Role;
using Admin.Domain.UserEntity;
using Admin.Domain.UserRole;
using Admin.EntityFrameworkCore;
using AutoMapper;
using ZLYY.Framework;
using ZLYY.Framework.Authentication.Password;
using ZLYY.Framework.Service;

namespace NetModular.Module.Admin.Application.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IAppRepository<UserEntity> _userRepository;
        private readonly IAppRepository<UserRoleEntity> _userRoleRepository;
        private readonly IAppRepository<RoleEntity> _roleRepository;
        private readonly IPasswordHandler _passwordHandler;

        public UserService(IMapper mapper,
            IAppRepository<UserEntity> userRepository, IAppRepository<UserRoleEntity> userRoleRepository,
            IAppRepository<RoleEntity> roleRepository, IPasswordHandler passwordHandler)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _passwordHandler = passwordHandler;
        }

        public async Task<IResultModel> Get(Guid id)
        {
            var user = await _userRepository.Get(id);
            if (user == null || user.IsDeleted)
                return ResultModel.Failed("用户不存在");
            return ResultModel.Success(user);
        }

        public async Task<IResultModel> Query(UserQueryModel model)
        {
            var result = new QueryResultModel<UserEntity>
            {
                Rows = _userRepository.Query(p => p.Name == model.Name).ToList(),
                Total = model.TotalCount
            };
            var db = _roleRepository.DbContext;
            foreach (var item in result.Rows)
            {
                item.Roles = (from user in db.Users
                              join userRole in db.UserRoles on user.Id equals userRole.UserId into t1
                              from tb1 in t1.DefaultIfEmpty()
                              join role in db.Roles on tb1.RoleId equals role.Id into t2
                              from tb2 in t2.DefaultIfEmpty()
                              select new OptionResultModel
                              {
                                  Value = tb2.Id,
                                  Label = tb2.Name
                              })
                         .ToList();
            }

            return ResultModel.Success(result);
        }

        public async Task<IResultModel<Guid>> Add(UserAddModel model)
        {
            var result = new ResultModel<Guid>();

            var user = _mapper.Map<UserEntity>(model);

            var exists = await Exists(user);
            if (!exists.IsSuccess)
                return exists;

            //设置默认密码
            if (string.IsNullOrWhiteSpace(user.Password))
                user.Password = PasswordSetting.DEFAULT_PWD;

            user.Password = _passwordHandler.Encrypt(user.UserName, user.Password);

            if (await _userRepository.Insert(user) > 0)
            {
                if (model.Roles != null && model.Roles.Any())
                {
                    var userRoleList = model.Roles.Select(m => new UserRoleEntity { UserId = user.Id, RoleId = m }).ToList();
                    if (await _userRoleRepository.Insert(userRoleList.ToArray()) > 0)
                        return result.Success(user.Id);
                }
                else
                    return result.Success(user.Id);
            }

            return result.Failed();
        }

        public async Task<IResultModel> Update(UserUpdateModel model)
        {
            var entity = await _userRepository.Get(model.Id);
            if (entity == null)
                return ResultModel.Failed("用户不存在！");
            if (entity.IsLock)
                return ResultModel.Failed("用户锁定，不允许修改");
            var user = _mapper.Map(model, entity);
            var exists = await Exists(user);
            if (!exists.IsSuccess)
                return exists;
            await _userRepository.Update(user);
            var userRoles = _userRoleRepository.Query(p => p.UserId == model.Id);
            if (userRoles.Any())
                await _userRoleRepository.Delete(userRoles.Select(p => p.Id).ToArray());
            if (model.Roles != null && model.Roles.Any())
            {
                var userRoleList = model.Roles.Select(m => new UserRoleEntity { UserId = user.Id, RoleId = m }).ToList();
                await _userRoleRepository.Insert(userRoleList.ToArray());
            }
            return ResultModel.Success();
        }

        public async Task<IResultModel> Delete(Guid id)
        {
            var user = await _userRepository.Get(id);
            if (user == null || user.IsDeleted)
                return ResultModel.Failed("用户不存在");
            if (user.IsLock)
                return ResultModel.Failed("用户锁定，不允许删除");
            var result = await _userRepository.Delete(id);
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> UpdatePassword(UpdatePasswordModel model)
        {
            var user = await _userRepository.Get(model.UserId);
            if (user == null || user.IsDeleted)
                return ResultModel.Failed("用户不存在");

            var oldPassword = _passwordHandler.Encrypt(user.UserName, model.OldPassword);
            if (!user.Password.Equals(oldPassword))
                return ResultModel.Failed("原密码错误");

            var newPassword = _passwordHandler.Encrypt(user.UserName, model.NewPassword);
            user.Password = newPassword;
            var result = await _userRepository.Update(p => p.Password, user);

            return ResultModel.Success(result);
        }

        public async Task<IResultModel> BindRole(UserRoleBindModel model)
        {
            var user = await _userRepository.Get(model.UserId);
            if (user == null || user.IsDeleted)
                return ResultModel.Failed("用户不存在");

            var exists = await _roleRepository.Exist(p => p.Id == model.RoleId);
            if (!exists)
                return ResultModel.Failed("角色不存在");

            //添加
            if (model.Checked)
            {
                exists = await _userRoleRepository.Exist(p => p.UserId == model.UserId && p.RoleId == model.RoleId);
                if (!exists)
                {
                    var result = await _userRoleRepository.Insert(new UserRoleEntity { UserId = model.UserId, RoleId = model.RoleId });
                    return ResultModel.Success(result);
                }

                return ResultModel.Success();
            }
            {
                //删除
                var result = await _userRoleRepository.Delete(model.UserId, model.RoleId);
                return ResultModel.Success(result);
            }
        }

        public async Task<IResultModel> ResetPassword(Guid id)
        {
            var user = await _userRepository.Get(id);
            if (user == null || user.IsDeleted)
                return ResultModel.Failed("用户不存在");
            if (user.IsLock)
                return ResultModel.Failed("用户锁定，不允许重置密码");

            user.Password = PasswordSetting.DEFAULT_PWD;
            var newPassword = _passwordHandler.Encrypt(user.UserName, user.Password);
            user.Password = newPassword;
            var result = await _userRepository.Update(p => p.Password, user);

            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Active(Guid id)
        {
            var user = await _userRepository.Get(id);
            if (user == null)
                return ResultModel.Failed("用户不存在");

            user.Status = UserStatus.Active;
            var result = await _userRepository.Update(p => p.Status, user);
            return ResultModel.Success(result);
        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private async Task<ResultModel<Guid>> Exists(UserEntity entity)
        {
            var result = new ResultModel<Guid>();

            if (await _userRepository.Exist(p => p.UserName == entity.UserName))
                return result.Failed("用户名已存在");
            if (!string.IsNullOrWhiteSpace(entity.Phone) && await _userRepository.Exist(p => p.Phone == entity.Phone))
                return result.Failed("手机号已存在");

            return result.Success(Guid.Empty);
        }
    }
}