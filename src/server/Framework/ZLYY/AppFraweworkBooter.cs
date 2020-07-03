// Creator: 程邵磊
// CreateTime: 2020/03/16

using Autofac;
using Microsoft.Extensions.Logging;
using ZLYY.Components.Logging;
using ZLYY.Framework.Dependency;
using ZLYY.Utils.Reflection;

namespace ZLYY
{
    public class AppFraweworkBooter
    {
        public ContainerBuilder ContainerBuilder { get; }

        protected AppFraweworkBooter(ContainerBuilder containerBuilder)
        {
            ContainerBuilder = containerBuilder;
            IocRegistrar.Instance.Builder = containerBuilder;
        }

        public static AppFraweworkBooter Create(ContainerBuilder containerBuilder)
        {
            return new AppFraweworkBooter(containerBuilder);
        }

        public void Register()
        {
            var assemblies = AssemblyHelper.GetAllAssemblies();
            // Register IOC by Assembly
            IocRegistrar.Instance.RegisterAssemblyTypes(assemblies);
            // Register IOC Modules
            IocRegistrar.Instance.RegisterAssemblyModules(assemblies);
        }

        public void Build(ILifetimeScope scope)
        {
            var logfactory = scope.Resolve<ILoggerFactory>();
            Logging.CreateLogger(logfactory);
        }
    }
}