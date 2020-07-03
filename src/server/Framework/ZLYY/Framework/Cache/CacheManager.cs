// FileInfo
// Creator:  程邵磊
// FileName:  CacheManager.cs
// CreateTime:  2019-10-18
// Remark：

using System.Collections.Concurrent;
using ZLYY.Framework.Dependency;

namespace ZLYY.Framework.Cache
{
    public class CacheManager : ICacheManager, ISingletonDependency
    {
        protected readonly ConcurrentDictionary<string, ICache> Caches;

        public CacheManager()
        {
            Caches = new ConcurrentDictionary<string, ICache>();
        }

        public void Dispose()
        {
            foreach (var cache in Caches.Values)
            {
                cache.Dispose();
            }
        }

        public ICache GetCache(string name)
        {
            return Caches.GetOrAdd(name, (cacheName) =>
            {
                var cache = CreateCacheImplementation(cacheName);

                return cache;
            });
        }

        private ICache CreateCacheImplementation(string cacheName)
        {
            return new AppMemoryCache(cacheName);
        }
    }
}