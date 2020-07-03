using System;
using System.IO;

namespace ZLYY.Utils.Helper
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="fullFileName"></param>
        /// <param name="fileData"></param>
        public static void SaveFile(string fullFileName, byte[] fileData)
        {
            var fileInfo = new FileInfo(fullFileName);
            var dir = fileInfo.Directory;
            if (dir != null && !dir.Exists)
                dir.Create();
            File.WriteAllBytes(fullFileName, fileData);
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="fullFileName"></param>
        public static string ReadFile(string fullFileName)
        {
            if (!File.Exists(fullFileName))
            {
                throw new FileNotFoundException("File not found", fullFileName);
            }
            using var fs = new FileStream(fullFileName, FileMode.Open, FileAccess.Read);
            using var sr = new StreamReader(fs);
            var content= sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return content;
        }
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="fullFileName"></param>
        public static byte[] GetFileByte(string fullFileName)
        {
            using var fs = new FileStream(fullFileName, FileMode.Open, FileAccess.Read);
            var bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            return bytes;
        }

        /// <summary>
        /// 删除指定文件 未找到文件不抛异常
        /// </summary>
        /// <param name="fullFileName"></param>
        public static void Delete(string fullFileName)
        {
            File.Delete(fullFileName);
        }

        /// <summary>
        /// 唯一文件名
        /// </summary>
        /// <returns></returns>
        public static string UniqueFileName(string prefix = "")
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            if (!string.IsNullOrEmpty(prefix))
                prefix += "_";
            return prefix + DateTime.Now.ToString("HHmmssffff") + rnd.Next(1, 10000);
        }

        /// <summary>
        /// 取后缀名
        /// </summary>
        /// <param name="fullFileName"></param>
        /// <returns></returns>
        public static string GetExtension(string fullFileName)
        {
            var fileInfo = new FileInfo(fullFileName);
            return fileInfo.Extension;
        }

        /// <summary>
        /// 取后文件名
        /// </summary>
        /// <param name="fullFileName"></param>
        /// <returns></returns>
        public static string GetFileName(string fullFileName)
        {
            var fileInfo = new FileInfo(fullFileName);
            return fileInfo.Name;
        }

        /// <summary>
        /// 文件大小(KB)
        /// </summary>
        /// <param name="fullFileName"></param>
        /// <returns></returns>
        public static double GetFileSize(string fullFileName)
        {
            var fileInfo = new FileInfo(fullFileName);
            return fileInfo.Length / 1000.0;
        }
    }
}
