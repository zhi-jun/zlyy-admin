// 
// FileInfo
// Creater:  程邵磊
// FileName:  StringConverter.cs
// CreateTime:  2018-12-13
// Remark：

using System;
using ZLYY.Utils.Helper;

namespace ZLYY.Utils.Extensions
{
    /// <summary>
    /// 字符串数据类型转换的string扩展类
    /// </summary>
    public static class StringConverter
    {
        /// <summary>
        /// Convert given string to int
        /// </summary>
        /// <param name="value"></param>
        /// <returns>int value, default -1</returns>
        public static int ToInt(this string value)
        {
            const int result = -1;
            if (string.IsNullOrWhiteSpace(value)) return result;
            return !RegexHelper.IsInt(value) ? result : int.Parse(value);
        }

        /// <summary>
        /// Convert given string to float
        /// </summary>
        /// <param name="value">default -1</param>
        /// <returns></returns>
        public static float ToFloat(this string value)
        {
            float result = -1;
            if (string.IsNullOrWhiteSpace(value))
                return result;
            if (!RegexHelper.IsNumeric(value))
                return result;
            result = float.Parse(value);
            return result;
        }

        /// <summary>
        ///  Convert given string to float
        /// </summary>
        /// <param name="value"></param>
        /// <returns>result:defualt -1.0</returns>
        public static double ToDouble(this string value)
        {
            const double result = -1.0;
            if (string.IsNullOrWhiteSpace(value))
                return result;
            return !RegexHelper.IsNumeric(value) ? result : double.Parse(value);
        }

        /// <summary>
        /// Convert given string to Boolean
        /// </summary>
        /// <param name="value"></param>
        /// <returns>return true if string is 'true' else return false</returns>
        public static bool ToBoolean(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            return value.ToLower() == "true";
        }

        /// <summary>
        /// Convert given string to DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            return Convert.ToDateTime(value);
        }

        /// <summary>
        /// Convert given string to Guid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string value)
        {
            var guid = Guid.Empty;
            if (value == null)
                return guid;
            if (string.IsNullOrWhiteSpace(value))
                return guid;
            Guid.TryParse(value, out guid);
            return guid;
        }

        /// <summary>
        /// Converts given string to enum.
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="value">String value to convert</param>
        /// <returns>Returns enum object</returns>
        public static T ToEnum<T>(this string value)
            where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// Converts ginven string to enum.
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="value">String value to convert</param>
        /// <param name="ignoreCase">Ignore case</param>
        /// <returns>Returns enum object</returns>
        public static T ToEnum<T>(this string value, bool ignoreCase)
            where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }
    }
}