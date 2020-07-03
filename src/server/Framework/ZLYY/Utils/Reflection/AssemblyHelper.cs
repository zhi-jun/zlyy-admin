// #Region FileInfo
// Creater:  程邵磊
// FileName:  AssemblyFinder.cs
// CreateTime:  2018/07/13
// #EndRegion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyModel;
using ZLYY.Utils.Extensions;

namespace ZLYY.Utils.Reflection
{
    public class AssemblyHelper
    {
        private static List<RuntimeLibrary> _allLibrarys;

        public static Assembly[] GetAllAssemblies()
        {
            _allLibrarys ??= DependencyContext.Default.RuntimeLibraries.Where(
                m => m.Type == "project" && HasProjectPrefix(m.Name))
                .ToList();

            return _allLibrarys
                .Select(m => AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(m.Name)))
                .ToArray();
        }

        public static Type[] FindTypes(Func<Type, bool> predicate)
        {
            return GetAllTypes().Where(predicate).ToArray();
        }

        public static Type[] GetAllTypes()
        {
            return GetAllAssemblies().SelectMany(o => o.GetTypes()).ToArray();
        }

        private static bool HasProjectPrefix(string typeName)
        {
            if (typeName.IsNullOrEmpty()) return false;
            //框架程序集前缀
            var frameworkAssemblyHeader = Assembly.GetExecutingAssembly().ManifestModule.Name.Split('.').FirstOrDefault();
            //应用程序集前缀
            var appAssemblyHeader = Assembly.GetEntryAssembly().ManifestModule.Name.Split('.').FirstOrDefault();
            return typeName.StartsWith(frameworkAssemblyHeader) || typeName.StartsWith(appAssemblyHeader);
        }
    }
}