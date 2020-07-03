using System.ComponentModel;

namespace ZLYY.Framework.Authentication
{
    /// <summary>
    /// 平台类型
    /// </summary>
    public enum Platform
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        UnKnown = 0,
        /// <summary>
        /// PC
        /// </summary>
        [Description("PC")]
        PC = 1,
        /// <summary>
        /// Phone Web
        /// </summary>
        [Description("PhoneWeb")]
        PhoneWeb = 2,
        /// <summary>
        /// Android
        /// </summary>
        [Description("Android")]
        Android = 3,
        /// <summary>
        /// IOS
        /// </summary>
        [Description("IOS")]
        IOS = 4,
        /// <summary>
        /// WeChat
        /// </summary>
        [Description("微信")]
        WeChat = 10,
        /// <summary>
        /// 小程序
        /// </summary>
        [Description("小程序")]
        MiniProgram = 11,
        /// <summary>
        /// 支付宝
        /// </summary>
        [Description("支付宝")]
        Alipay = 20
    }
}
