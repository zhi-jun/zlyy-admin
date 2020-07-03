// Creator: 程邵磊
// CreateTime: 2020/03/17

using System;
using System.Reflection;
using Autofac;
using Autofac.Core;

namespace ZLYY.Framework.Dependency
{
    internal class IocRegistrar : IDisposable
    {
        public ContainerBuilder Builder { get; set; }

        public static IocRegistrar Instance { get; }

        static IocRegistrar()
        {
            Instance = new IocRegistrar();
        }

        public void RegisterAssemblyTypes(params Assembly[] assemblies)
        {
            Builder.RegisterAssemblyTypes(assemblies)
                .Except<ISingletonDependency>()
                .Except<IRequestDependency>()
                .Except<ITransientDependency>()
                .AsImplementedInterfaces();
            Builder.RegisterAssemblyTypes(assemblies).Where(o => typeof(ISingletonDependency).IsAssignableFrom(o))
                .AsImplementedInterfaces().SingleInstance();
            Builder.RegisterAssemblyTypes(assemblies).Where(o => typeof(IRequestDependency).IsAssignableFrom(o))
                .AsImplementedInterfaces().InstancePerRequest();
            Builder.RegisterAssemblyTypes(assemblies).Where(o => typeof(ITransientDependency).IsAssignableFrom(o))
                .AsImplementedInterfaces().InstancePerDependency();
        }

        public void RegisterAssemblyModules(params Assembly[] assemblies)
        {
            Builder.RegisterAssemblyModules<IModule>(assemblies);
        }

        public void Dispose()
        {
            Builder = null;
        }
    }
}