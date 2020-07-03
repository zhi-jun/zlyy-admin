// Creator: 程邵磊
// CreateTime: 2020/03/18

using Autofac;
using ZLYY.Utils.Reflection;

namespace Admin.ApplicationModule
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = AssemblyHelper.GetAllAssemblies();
            builder.RegisterAssemblyTypes(assemblies).Where(o => !o.IsInterface && !o.IsAbstract)
                .AsImplementedInterfaces();
        }
    }
}