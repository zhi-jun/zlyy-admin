using System;
using Autofac.Extras.DynamicProxy;
using ZLYY.Framework.Dependency;

namespace ZLYY.Framework.Aop
{
    /// <summary>
    /// 拦截类型
    /// </summary>
    public class AspectAttribute : InterceptAttribute
    {
        public AspectAttribute(Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Request) : base(type)
        {
            LiftStyle = lifeStyle;
        }

        /// <summary>
        /// 生命周期,默认:Scoped
        /// </summary>
        public DependencyLifeStyle LiftStyle { get; }
    }
}
