// #Region FileInfo
// Creater:  程邵磊
// FileName:  StreamExtensions.cs
// CreateTime:  2018/06/26
// #EndRegion
// 

using System.IO;

namespace ZLYY.Utils.Extensions
{
    /// <summary>
    /// Stream Extension
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Get memory stream array bytes
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] GetAllBytes(this Stream stream)
        {
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}