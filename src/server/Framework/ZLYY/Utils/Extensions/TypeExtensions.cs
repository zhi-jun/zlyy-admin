// Creator: 程邵磊
// CreateTime: 2020/03/17

using System;

namespace ZLYY.Utils.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsSubOf<TBaseType>(this Type type)
        {
            var baseType = typeof(TBaseType);
            if (baseType.IsClass)
                return type.IsSubclassOf(typeof(TBaseType));
            return typeof(TBaseType).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract;
        }
    }
}