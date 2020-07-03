// FileInfo
// Creator:  程邵磊
// FileName:  ICache.cs
// CreateTime:  2019-10-17
// Remark：

using System;
using System.Collections.Generic;

namespace ZLYY.Framework.Cache
{
    public interface ICache : IDisposable
    {
        /// <summary>
        /// Unique name of the cache.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Default sliding expire time of cache items.
        /// Default value: 60 minutes (1 hour).
        /// Can be changed by configuration.
        /// </summary>
        TimeSpan DefaultSlidingExpireTime { get; set; }

        /// <summary>
        /// Default absolute expire time of cache items.
        /// Default value: null (not used).
        /// </summary>
        TimeSpan? DefaultAbsoluteExpireTime { get; set; }

        /// <summary>
        /// Gets an item from the cache or null if not found.
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Cached item or null if not found</returns>
        T Get<T>(string key) where T : class;

        /// <summary>
        /// Saves/Overrides an item in the cache by a key.
        /// Use one of the expire times at most (<paramref name="slidingExpireTime"/> or <paramref name="absoluteExpireTime"/>).
        /// If none of them is specified, then
        /// <see cref="DefaultAbsoluteExpireTime"/> will be used if it's not null. Othewise, <see cref="DefaultSlidingExpireTime"/>
        /// will be used.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="slidingExpireTime">Sliding expire time</param>
        /// <param name="absoluteExpireTime">Absolute expire time</param>
        bool Set(string key, object value, TimeSpan? slidingExpireTime = null, TimeSpan? absoluteExpireTime = null);

        /// <summary>
        /// Saves/Overrides items in the cache by the pairs.
        /// Use one of the expire times at most (<paramref name="slidingExpireTime"/> or <paramref name="absoluteExpireTime"/>).
        /// If none of them is specified, then
        /// <see cref="DefaultAbsoluteExpireTime"/> will be used if it's not null. Othewise, <see cref="DefaultSlidingExpireTime"/>
        /// will be used.
        /// </summary>
        /// <param name="pairs">Pairs</param>
        /// <param name="slidingExpireTime">Sliding expire time</param>
        /// <param name="absoluteExpireTime">Absolute expire time</param>
        void Set(KeyValuePair<string, object>[] pairs, TimeSpan? slidingExpireTime = null, TimeSpan? absoluteExpireTime = null);

        /// <summary>
        /// Removes a cache item by it's key (does nothing if given key does not exists in the cache).
        /// </summary>
        /// <param name="key">Key</param>
        void Remove(string key);

        /// <summary>
        /// Removes cache items by their keys.
        /// </summary>
        /// <param name="keys">Keys</param>
        void Remove(string[] keys);

        /// <summary>
        /// Clears all items in this cache.
        /// </summary>
        void Clear();
    }
}