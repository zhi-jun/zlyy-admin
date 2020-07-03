using System;

namespace ZLYY.Components.AutoMapper
{
    public abstract class MapperAttributeBase : Attribute
    {
        public Type[] TargetTypes { get; private set; }

        protected MapperAttributeBase(params Type[] targetTypes)
        {
            TargetTypes = targetTypes;
        }

        public abstract void CreateMap(MapperProfile mapperProfile, Type type);
    }
}
