using Admin.Domain.Menu;
using Admin.Domain.Module;
using Admin.Domain.Role;
using Admin.Domain.RoleButton;
using Admin.Domain.RoleMenu;
using Admin.Domain.RolePage;
using Admin.Domain.RolePermission;
using Admin.Domain.UserEntity;
using Admin.Domain.UserRole;
using Microsoft.EntityFrameworkCore;
using ZLYY.Framework.Data.EntityFramework;

namespace Admin.EntityFrameworkCore
{
    public class AppDbContext : BaseDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<MenuEntity> Menus { get; set; }
        public virtual DbSet<ModuleEntity> Modules { get; set; }
        public virtual DbSet<RoleEntity> Roles { get; set; }
        public virtual DbSet<RoleButtonEntity> RoleButtons { get; set; }
        public virtual DbSet<RoleMenuEntity> RoleMenus { get; set; }
        public virtual DbSet<RolePageEntity> RolePages { get; set; }
        public virtual DbSet<RolePermissionEntity> RolePermissions { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<UserRoleEntity> UserRoles { get; set; }
    }
}
