// Creator: 程邵磊
// CreateTime: 2020/03/27

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using ZLYY.Components.Jwt;
using ZLYY.Framework.Dependency;
using ZLYY.Utils.Extensions;

namespace ZLYY.Framework.Authentication.Token
{
    public class JwtTokenProvider : ITokenProvider, ISingletonDependency
    {
        private readonly IConfiguration _configuration;

        public JwtTokenProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetToken(Claim[] claims)
        {
            var authTime = DateTime.Now;
            var expiresMinute = _configuration[JwtSetting.TOKE_NEXPIRES].ToInt();
            var expiresAt = authTime.AddMinutes(expiresMinute);

            // Show PII in log
            IdentityModelEventSource.ShowPII = true;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                IssuedAt = authTime, 
                Expires = expiresAt,
                NotBefore = authTime,
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtSetting.SECURITY_KEY)),
                        SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandle = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandle.CreateToken(tokenDescriptor);
            return tokenHandle.WriteToken(jwtToken);
        }
    }
}