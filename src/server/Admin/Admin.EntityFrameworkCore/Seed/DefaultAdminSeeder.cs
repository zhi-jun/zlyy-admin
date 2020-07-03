// Creator: 程邵磊
// CreateTime: 2020/04/01

using System.Collections.Generic;
using System.Linq;
using Admin.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZLYY.Framework.Data.MultiTenant;

namespace Admin.EntityFrameworkCore.Seed
{
    public class DefaultAdminSeeder
    {
        public void Create(AppDbContext context)
        {
            //// 超级管理员角色
            //var roles = context.Roles.IgnoreQueryFilters();
            //var superAdminRole = roles.FirstOrDefault(o => o.Name == RoleNames.SuperAdmin);
            //if (superAdminRole == null)
            //{
            //    superAdminRole = new RoleEntity(RoleNames.SuperAdmin, "超级管理员");
            //    context.Roles.Add(superAdminRole);
            //    //context.SaveChanges();
            //}

            //// 超级管理员权限
            //var grantedPermissions = context.RolePermissionSettings.IgnoreQueryFilters()
            //    .Where(p => p.TenantId == null && p.RoleId == superAdminRole.Id)
            //    .Select(p => p.Name)
            //    .ToList();
            //var permissions = PermissionFinder
            //    .GetAllPermissions(new AppAuthorizationProvider())
            //    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Host) && !grantedPermissions.Contains(p.Name))
            //    .ToList();
            //if (permissions.Any())
            //{
            //    context.RolePermissionSettings.AddRange(
            //        permissions.Select(permission => new RolePermissionSetting
            //        {
            //            TenantId = null,
            //            Name = permission.Name,
            //            RoleId = superAdminRole.Id
            //        })
            //    );
            //    //context.SaveChanges();
            //}

            //// 超级管理员用户
            //if (!context.Users.Any(o=>o.UserName=="admin"))
            //{
            //    var superAdminUser = new UserEntity("admin", "超级管理员");
            //    superAdminUser.Password=new PasswordHasher<UserEntity>().HashPassword(superAdminUser,"asdf1234");
            //    superAdminUser.Roles = new List<UserRole>
            //    {
            //        new UserRole {RoleId = superAdminRole.Id, UserId = superAdminUser.Id}
            //    };
            //    context.Users.Add(superAdminUser);
            //    //context.SaveChanges();
            //}
            context.SaveChanges();
        }
    }
}