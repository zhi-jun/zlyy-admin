using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace ZLYY.Components.Logging
{
    /// <summary>
    /// 日志类
    /// </summary>
    public class Logging
    {
        #region Instance

        private static ILoggerFactory ILoggerFactory;

        //单例(延时+缓存)
        private static Lazy<ILogger> InstanceLazy;
        
        //日志对象
        private static ILogger Logger => ILoggerFactory == null ? null : InstanceLazy.Value;

        #endregion

        public static void CreateLogger(ILoggerFactory loggerFactory)
        {
            ILoggerFactory = loggerFactory;
            InstanceLazy = new Lazy<ILogger>(() => loggerFactory.CreateLogger(string.Empty));
        }

        //缓存日志
        //ioc未构建完成出现错误先缓存,会自动生成日志
        static List<(string type, string message)> LogCache = new List<(string type, string message)>();

        /// <summary>
        /// Ioc容器未构建,只缓存不写文件
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        static bool CheckLog(string type, string message)
        {
            if (Logger == null)
            {
                LogCache.Add(ValueTuple.Create(type, message));
                return false;
            }

            if (LogCache != null)
            {
                foreach (var item in LogCache)
                {
                    switch (item.type)
                    {
                        case "Debug":
                            Logger.LogDebug(item.message);
                            break;
                        case "Info":
                            Logger.LogInformation(item.message);
                            break;
                        case "Warn":
                            Logger.LogWarning(item.message);
                            break;
                        case "Error":
                            Logger.LogError(item.message);
                            break;
                    }
                }

                //清除缓存
                LogCache = null;
            }
            return true;
        }

        /// <summary>
        /// 信息
        /// </summary>
        public static void Debug(string message)
        {
            if (!CheckLog("Debug", message))
                return;
            Logger.LogDebug(message);
        }

        /// <summary>
        /// 信息
        /// </summary>
        public static void Info(string message)
        {
            if (!CheckLog("Info", message))
                return;
            Logger.LogInformation(message);
        }

        /// <summary>
        /// 警告
        /// </summary>
        public static void Warn(string message)
        {
            if (!CheckLog("Warn", message))
                return;
            Logger.LogWarning(message);
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="ex"></param>
        public static void Error(Exception ex)
        {
            Error(ex.Message, ex);
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Error(string message, Exception ex = null)
        {
            if (!CheckLog("Error", message))
                return;

            if (ex != null)
            {
                string errorMsg = $"{ex.Message} \r\n【StackTrace】：{ex.StackTrace}";
                Logger.LogError(errorMsg);
            }

            Logger.LogError(message, ex);
        }
    }
}
