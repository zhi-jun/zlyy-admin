using System;

namespace ZLYY.Components.Swagger
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class HiddenApiAttribute : Attribute { }
}
