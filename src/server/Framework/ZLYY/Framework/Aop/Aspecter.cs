using System.Reflection;
using Castle.DynamicProxy;

namespace ZLYY.Framework.Aop
{
    /// <summary>
    /// 拦截器
    /// </summary>
    public abstract class Aspecter : IInterceptor
    {
        /// <summary>
        /// 执行前
        /// </summary>
        /// <param name="method">方法</param>
        /// <param name="arguments">参数</param>
        public abstract void Before(MethodInfo method, object[] arguments);

        /// <summary>
        /// 执行后
        /// </summary>
        /// <param name="method">方法</param>
        /// <param name="arguments">参数</param>
        /// <param name="returnValue">返回值</param>
        public abstract void After(MethodInfo method, object[] arguments, object returnValue);

        //拦截
        public virtual void Intercept(IInvocation invocation)
        {
            Before(invocation.Method, invocation.Arguments);
            invocation.Proceed();
            After(invocation.Method, invocation.Arguments, invocation.ReturnValue);
        }
    }
}
