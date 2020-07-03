using Admin.Application.UserService.ViewModels;
using Admin.Domain.UserEntity;
using ZLYY.Components.AutoMapper;

namespace Admin.Application.Application.UserService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(MapperProfile cfg)
        {
            cfg.CreateMap<UserAddModel, UserEntity>().ForMember(m => m.Roles, opt => opt.Ignore());
            cfg.CreateMap<UserSyncModel, UserEntity>().ForMember(m => m.Roles, opt => opt.Ignore());

            cfg.CreateMap<UserEntity, UserUpdateModel>();
            cfg.CreateMap<UserUpdateModel, UserEntity>().ForMember(m => m.Roles, opt => opt.Ignore());
        }
    }
}
