using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using ZLYY.Framework.Dependency;
using ZLYY.Utils.Collections;
using Autofac;

namespace ZLYY.Components.AutoMapper
{
    /// <summary>
    /// 配置映射关系
    /// </summary>
    public class MapperProfile : Profile, ISingletonDependency
    {
        List<(Type Source, Type Target)> Tuples = new List<(Type Source, Type Target)>();

        public void Mapping<TSource, TTarget>()
        {
            Tuples.AddIfNotExist(ValueTuple.Create(typeof(TSource), typeof(TTarget)));
        }

        public void BuildMapper()
        {
            if (!Tuples.Any())
                return;

            foreach (var tuple in Tuples)
            {
                CreateMap(tuple.Source, tuple.Target);
            }

            var config = new MapperConfiguration(cfg => cfg.AddProfile(this));

            //注入IMapper
            IocRegistrar.Instance.Builder.RegisterInstance(config.CreateMapper()).SingleInstance();
        }
    }

}
