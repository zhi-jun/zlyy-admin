using Autofac;

namespace ZLYY.Components.AutoMapper
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MapperProfile>().PropertiesAutowired();
        }
    }
}
