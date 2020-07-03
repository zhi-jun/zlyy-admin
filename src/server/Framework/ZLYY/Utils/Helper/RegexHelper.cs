using System.Text.RegularExpressions;

namespace ZLYY.Utils.Helper
{
    /// <summary>
    /// 正则表达式帮助类
    /// </summary>
    public static class RegexHelper
    {
        #region Numeric
        /// <summary>
        /// 是否为数值
        /// </summary>
        /// <param name="value">数值</param>
        /// <returns>是否为数值</returns>
        public static bool IsNumeric(string value)
        {
            if (value == null)
                return false;
            if (value == "+." || value == "-.")
                return false;
            return Regex.IsMatch(value, @"^[-|+]?\d*[.]?\d*[^+|^-]$");
        }

        /// <summary>
        /// 是否为字母或数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumOrCharacter(string value)
        {
            return Regex.IsMatch(value, @"^[A-Za-z0-9]+$");
        }

        /// <summary>
        /// 是否为负数
        /// </summary>
        /// <param name="value">数值</param>
        /// <returns>是否为负数</returns>
        public static bool IsPositiveNumeric(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            if (value == "+." || value == "-.")
                return false;
            return Regex.IsMatch(value, @"^[+]?\d*[.]?\d*$");
        }

        /// <summary>
        /// 是否为整型
        /// </summary>
        /// <param name="value">数值</param>
        /// <param name="allowEmpty">是否允许空格</param>
        /// <returns>是否为整型</returns>
        public static bool IsInt(string value, bool allowEmpty = false)
        {
            // 判断是否是有效字符串
            if (!allowEmpty && string.IsNullOrWhiteSpace(value))
                return false;
            if (allowEmpty && string.IsNullOrWhiteSpace(value))
                return true;
            return Regex.IsMatch(value, @"^[-|+]?[0-9]\d*$");
        }

        /// <summary>
        /// 正整数
        /// </summary>
        /// <returns></returns>
        public static bool IsPositiveInteger(string value, bool notAllowEmpty = false)
        {
            if (!notAllowEmpty && string.IsNullOrWhiteSpace(value))
                return false;
            if (notAllowEmpty && string.IsNullOrWhiteSpace(value))
                return true;
            // 增加对 +1,+123 识别
            // 增加对 01,0123 识别
            // 增加对 +01,+0123 识别
            return Regex.IsMatch(value, @"^[+]?[0*]?[1-9]\d*$");
        }
        #endregion

        #region Common type
        /// <summary>
        /// 是否为时间
        /// </summary>
        /// <param name="timeval"></param>
        /// <returns></returns>
        public static bool IsTime(string timeval)
        {
            return Regex.IsMatch(timeval, @"20\d{2}\-[0-1]{1,2}\-[0-3]?[0-9]?(\s*((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?))?");
        }

        /// <summary>
        /// 是否为Guid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsGuid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            return Regex.IsMatch(value, @"^[a-fA-F0-9]{8}-([a-fA-F0-9]{4}-){3}[a-fA-Z0-9]{12}$");
        }
        #endregion

        #region Personal Info
        /// <summary>
        /// 匹配电话号码是否合法
        /// </summary>
        /// <param name="source">待匹配字符串</param>
        /// <returns>电话号码合法返回true,反之不合法</returns>
        public static bool IsTelephone(string source)
        {
            const string str = @"^(\(\d{3,4}-)|\d{3.4}-)?\d{7,8}$";
            var rg = new Regex(str);
            return rg.IsMatch(source);
        }

        /// <summary>
        /// 匹配手机号码是否合法
        /// </summary>
        /// <param name="source">待匹配字符串</param>
        /// <returns>手机号码合法返回true,反之不合法</returns>
        public static bool IsMobilephone(string source)
        {
            var rg = new Regex(@"^[1]+[3,5]+\d{9}$");
            return rg.IsMatch(source);
        }

        /// <summary>
        /// 匹配邮政编码是否合法
        /// </summary>
        /// <param name="postCode"></param>
        /// <returns></returns>
        public static bool IsPostCode(string postCode)
        {
            return Regex.IsMatch(postCode, @"^\d{6}$");
        }

        /// <summary>
        /// 匹配身份证号码是否合法
        /// </summary>
        /// <param name="source">待匹配字符串</param>
        /// <returns>身份证号码合法返回true,反之不合法</returns>
        public static bool IsIDNo(string source)
        {
            var rg = new Regex(@"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$");
            return rg.IsMatch(source);
        }

        /// <summary>
        /// 检测密码复杂度是否达标：密码中必须包含字母、数字、特称字符
        /// </summary>
        /// <param name="source">待匹配字符串</param>
        /// <param name="minLength">最小字符长度</param>
        /// <param name="maxLength">最大字符长度</param>
        /// <returns>密码复杂度是否达标true是达标反之不达标</returns>
        public static bool IsPasswordValid(string source, int minLength = 6, int maxLength = 16)
        {
            var rg = new Regex(@"^(?=.*\d)(?=.*[a-zA-Z])(?=.*[^a-zA-Z0-9]).{" + minLength + "," + maxLength + "}$");
            return rg.IsMatch(source);
        }

        #endregion

        #region Net
        /// <summary>
        /// 是否为Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsUrl(string url)
        {
            return !string.IsNullOrEmpty(url)
                   && Regex.IsMatch(url, @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$");
        }

        /// <summary>
        /// 是否IP地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            if (string.IsNullOrEmpty(ip))
            {
                return true;
            }
            ip = ip.Trim();
            const string pattern = @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$";
            return Regex.IsMatch(ip, pattern);
        }

        /// <summary>
        /// 获取域名
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetDomainName(string url)
        {
            var rg = new Regex("(?<=(//))[.\\s\\S]*?(?=(/|:))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(url).Value;
        } 
        #endregion
    }
}
