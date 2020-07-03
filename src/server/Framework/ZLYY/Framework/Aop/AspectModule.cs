using Autofac;
using Autofac.Extras.DynamicProxy;
using ZLYY.Framework.Dependency;
using ZLYY.Utils.Extensions;
using ZLYY.Utils.Reflection;

namespace ZLYY.Framework.Aop
{
    /// <summary>
    /// Aop模块
    /// </summary>
    public class AspectModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // 注入Aop
            var aspectTypes = AssemblyHelper.FindTypes(t => t.HasAttribute<AspectAttribute>());
            //注入拦截器
            var aopTypes = AssemblyHelper.FindTypes(t => t.BaseType != null && t.IsSubOf<Aspecter>());
            builder.RegisterTypes(aopTypes).SingleInstance();

            //注入拦截对象 并启动拦截
            foreach (var type in aspectTypes)
            {
                var interceptors = builder.RegisterType(type).EnableClassInterceptors();
                var attr = type.GetAttribute<AspectAttribute>();
                switch (attr.LiftStyle)
                {
                    //单例
                    case DependencyLifeStyle.Singleton:
                        interceptors.SingleInstance();
                        break;
                    //一次Http请求上下文
                    case DependencyLifeStyle.Request:
                        interceptors.InstancePerLifetimeScope();
                        break;
                    //瞬时
                    case DependencyLifeStyle.Transient:
                        interceptors.InstancePerDependency();
                        break;
                }
            }
        }
    }
}
