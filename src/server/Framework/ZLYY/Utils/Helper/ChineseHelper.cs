// #Region FileInfo
// Creater:  程邵磊
// FileName:  ChineseExtension.cs
// CreateTime:  2018/10/27
// #EndRegion
// 
namespace NcpPdr.Helper
{
    /// <summary>
    /// 汉语帮助类
    /// </summary>
    public class ChineseHelper
    {
        /// <summary>
        /// 获取拼音全拼，支持多音,小写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToPinyin(string str)
        {
            return ToolGood.Words.WordsHelper.GetPinYin(str).ToLower();
        }

        /// <summary>
        /// 获取拼音首拼,小写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToFirstPinyin(string str)
        {
            return ToolGood.Words.WordsHelper.GetFirstPinYin(str).ToLower();
        }

        /// <summary>
        /// 判断字符串是否包含中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool HasChinese(string str)
        {
            return ToolGood.Words.WordsHelper.HasChinese(str);
        }

        /// <summary>
        /// 判断字符串是否包含英文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool HasEnglish(string str)
        {
            return ToolGood.Words.WordsHelper.HasEnglish(str);
        }

        /// <summary>
        /// 将字符串转换为半角
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToDBC(string str)
        {
            return ToolGood.Words.WordsHelper.ToDBC(str);
        }

        /// <summary>
        /// 将字符串转换为全角
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToSBC(string str)
        {
            return ToolGood.Words.WordsHelper.ToSBC(str);
        }
    }
}