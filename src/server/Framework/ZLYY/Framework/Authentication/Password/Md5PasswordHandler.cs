﻿using System;
using ZLYY.Framework.Dependency;
using ZLYY.Utils.Encrypt;

namespace ZLYY.Framework.Authentication.Password
{
    /// <summary>
    /// 密码处理器
    /// </summary>
    public class Md5PasswordHandler : IPasswordHandler, ISingletonDependency
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public string Encrypt(string userName, string password)
        {
            return Md5Encrypt.Encrypt($"{userName.ToLower()}_{password}");
        }

        public string Decrypt(string encryptPassword)
        {
            throw new NotSupportedException("MD5加密无法解密");
        }
    }
}
