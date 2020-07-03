using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin.Migrator.Migrations
{
    public partial class v0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ModifyUser = table.Column<Guid>(nullable: true),
                    CreateUser = table.Column<Guid>(nullable: false),
                    ModuleCode = table.Column<string>(maxLength: 32, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: true),
                    RouteName = table.Column<string>(maxLength: 32, nullable: true),
                    RouteParams = table.Column<string>(maxLength: 512, nullable: true),
                    RouteQuery = table.Column<string>(maxLength: 512, nullable: true),
                    Url = table.Column<string>(maxLength: 128, nullable: true),
                    Icon = table.Column<string>(maxLength: 32, nullable: true),
                    IconColor = table.Column<string>(maxLength: 32, nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Show = table.Column<bool>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    Target = table.Column<int>(nullable: false),
                    DialogWidth = table.Column<string>(maxLength: 32, nullable: true),
                    DialogHeight = table.Column<string>(maxLength: 32, nullable: true),
                    DialogFullscreen = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 32, nullable: true),
                    ParentName = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ModifyUser = table.Column<Guid>(nullable: true),
                    CreateUser = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Code = table.Column<string>(maxLength: 32, nullable: false),
                    Icon = table.Column<string>(maxLength: 32, nullable: true),
                    Version = table.Column<string>(maxLength: 32, nullable: true),
                    Remarks = table.Column<string>(maxLength: 32, nullable: true),
                    ApiRequestCount = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: true),
                    IsSpecified = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role_Button",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ModifyUser = table.Column<Guid>(nullable: true),
                    CreateUser = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    PageCode = table.Column<string>(maxLength: 128, nullable: true),
                    ButtonCode = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Button", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role_Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ModifyUser = table.Column<Guid>(nullable: true),
                    CreateUser = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    MenuId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role_Page",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ModifyUser = table.Column<Guid>(nullable: true),
                    CreateUser = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    PageCode = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Page", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role_Permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ModifyUser = table.Column<Guid>(nullable: true),
                    CreateUser = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    PermissionCode = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ModifyUser = table.Column<Guid>(nullable: true),
                    CreateUser = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 32, nullable: true),
                    Password = table.Column<string>(maxLength: 32, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Phone = table.Column<string>(maxLength: 32, nullable: true),
                    Email = table.Column<string>(maxLength: 32, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsLock = table.Column<bool>(nullable: false),
                    ClosedTime = table.Column<DateTime>(nullable: false),
                    ClosedBy = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ModifyUser = table.Column<Guid>(nullable: true),
                    CreateUser = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Role", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Role_Button");

            migrationBuilder.DropTable(
                name: "Role_Menu");

            migrationBuilder.DropTable(
                name: "Role_Page");

            migrationBuilder.DropTable(
                name: "Role_Permission");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "User_Role");
        }
    }
}
