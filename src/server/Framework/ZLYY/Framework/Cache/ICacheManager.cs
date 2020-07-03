// FileInfo
// Creator:  程邵磊
// FileName:  ICacheManager.cs
// CreateTime:  2019-10-18
// Remark：

using System;

namespace ZLYY.Framework.Cache
{
    public interface ICacheManager : IDisposable
    {
        /// <summary>
        /// Gets a <see cref="ICache"/> instance.
        /// It may create the cache if it does not already exists.
        /// </summary>
        /// <param name="name">
        /// Unique and case sensitive name of the cache.
        /// </param>
        /// <returns>The cache reference</returns>
        ICache GetCache(string name);
    }
}