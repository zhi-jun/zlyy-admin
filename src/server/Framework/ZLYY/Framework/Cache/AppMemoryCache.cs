// FileInfo
// Creator:  程邵磊
// FileName:  AppMemoryCache.cs
// CreateTime:  2019-10-17
// Remark：


using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace ZLYY.Framework.Cache
{
    public class AppMemoryCache : ICache
    {
        public string Name { get; }
        public TimeSpan DefaultSlidingExpireTime { get; set; }
        public TimeSpan? DefaultAbsoluteExpireTime { get; set; }

        private Lazy<MemoryCache> _instanceLazy;
        private MemoryCache Cache => _instanceLazy.Value;

        public AppMemoryCache(string name)
        {
            Name = name;
            DefaultSlidingExpireTime = TimeSpan.FromHours(1);
            _instanceLazy = new Lazy<MemoryCache>(() => new MemoryCache(new MemoryCacheOptions()));
        }

        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            var p = Cache.TryGetValue(key, out _);
            return p;
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public T Get<T>(string key) where T : class
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (Exists(key))
            {
                return Cache.Get(key) as T;
            }
            return default(T);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="slidingExpireTime"></param>
        /// <param name="absoluteExpireTime"></param>
        public bool Set(string key, object value, TimeSpan? slidingExpireTime,
            TimeSpan? absoluteExpireTime = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var op = new MemoryCacheEntryOptions().SetSlidingExpiration(slidingExpireTime.HasValue ? slidingExpireTime.Value : DefaultSlidingExpireTime);
            if (absoluteExpireTime.HasValue)
                op.SetAbsoluteExpiration(absoluteExpireTime.Value);
            Cache.Set(key, value, op);
            return Exists(key);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="pairs"></param>
        /// <param name="slidingExpireTime"></param>
        /// <param name="absoluteExpireTime"></param>
        public void Set(KeyValuePair<string, object>[] pairs, TimeSpan? slidingExpireTime = null, TimeSpan? absoluteExpireTime = null)
        {
            foreach (var pair in pairs)
            {
                Set(pair.Key, pair.Value, slidingExpireTime, absoluteExpireTime);
            }
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            Cache.Remove(key);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="keys"></param>
        public void Remove(string[] keys)
        {
            foreach (var key in keys)
            {
                Remove(key);
            }
        }

        /// <summary>
        /// 重置缓存
        /// </summary>
        public void Clear()
        {
            Cache.Dispose();
            _instanceLazy = new Lazy<MemoryCache>(() => new MemoryCache(new MemoryCacheOptions()));
        }


        /// <summary>
        /// 释放缓存
        /// </summary>
        public void Dispose()
        {
            Cache?.Dispose();
        }
    }
}