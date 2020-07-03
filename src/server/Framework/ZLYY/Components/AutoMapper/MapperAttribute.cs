using Castle.Core.Internal;
using System;
namespace ZLYY.Components.AutoMapper
{
    /// <summary>
    /// 双向映射
    /// </summary>
    public class MapperAttribute : MapperAttributeBase
    {
        public MapperAttribute(params Type[] targetTypes)
            : base(targetTypes)
        {

        }

        public override void CreateMap(MapperProfile mapperProfile, Type type)
        {
            if (TargetTypes.IsNullOrEmpty())
            {
                return;
            }

            foreach (var targetType in TargetTypes)
            {
                mapperProfile.CreateMap(type, targetType);
                mapperProfile.CreateMap(targetType, type);
            }
        }
    }
}
