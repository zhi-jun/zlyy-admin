﻿// Creator: 程邵磊
// CreateTime: 2020/03/18

using System.Linq;
using System.Reflection;
using Autofac.Core;
using Autofac.Core.Registration;
using log4net;
using NcpPdr.Framework.Module;

namespace NcpPdr.Component.Logging
{
    public class LoggingModule : AppModule
    {
        private static void InjectLoggerProperties(object instance)
        {
            var instanceType = instance.GetType();

            // Get all the injectable properties to set.
            // If you wanted to ensure the properties were only UNSET properties,
            // here's where you'd do it.
            var properties = instanceType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(ILog) && p.CanWrite && p.GetIndexParameters().Length == 0);

            // Set the properties located.
            foreach (var propToSet in properties)
            {
                propToSet.SetValue(instance, LogManager.GetLogger(instanceType), null);
            }
        }

        private static void OnComponentPreparing(object sender, PreparingEventArgs e)
        {
            e.Parameters = e.Parameters.Union(
                new[]
                {
                    new ResolvedParameter(
                        (p, i) => p.ParameterType == typeof(ILog),
                        (p, i) => LogManager.GetLogger(p.Member.DeclaringType)
                    ),
                });
        }

        protected override void AttachToComponentRegistration(IComponentRegistryBuilder componentRegistryBuilder, IComponentRegistration registration)
        {
            // Handle constructor parameters.
            registration.Preparing += OnComponentPreparing;

            // Handle properties.
            registration.Activated += (sender, e) => InjectLoggerProperties(e.Instance);
        }
    }
}