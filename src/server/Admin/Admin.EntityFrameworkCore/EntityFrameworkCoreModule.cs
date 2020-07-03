// Creator: 程邵磊
// CreateTime: 2020/03/18

using Autofac;
using Autofac.Core;
using Microsoft.EntityFrameworkCore;

namespace Admin.EntityFrameworkCore
{
    public class EntityFrameworkCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppDbContext>().WithParameter(new ResolvedParameter(
                (info, context) => info.ParameterType == typeof(DbContextOptions),
                (info, context) => context.Resolve<IDbContextConfiguration>().GetDbContextOptions())).PropertiesAutowired();
            builder.RegisterGeneric(typeof(AppRepository<>)).As(typeof(IAppRepository<>));
        }
    }
}