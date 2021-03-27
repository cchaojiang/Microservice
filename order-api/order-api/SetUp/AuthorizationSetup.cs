using Common.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order_api.SetUp
{
    public static class AuthorizationSetup
    {
        public static void AddAuthorizationSetup(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            //添加授权策略
            services.AddAuthorization(option => {
                option.AddPolicy("Admin", policy => policy.RequireRole("admin", "system","guest","qc"));
                option.AddPolicy("System", policy => policy.RequireRole("admin", "system"));
            });
            //读取配置文件
            var symmetricKeyAsBase64 = AppSettings.app(new string[] { "AppSettings", "JwtSetting", "SecretKey" });
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var Issuer = AppSettings.app(new string[] { "AppSettings", "JwtSetting", "Issuer" });
            var Audience = AppSettings.app(new string[] { "AppSettings", "JwtSetting", "Audience" });

            // 令牌验证参数
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,   //是否验证秘钥
                IssuerSigningKey = signingKey,  //秘钥
                ValidateIssuer = true,   ////是否验证发行人
                ValidIssuer = Issuer,//发行人
                ValidateAudience = true,  //是否验证受众
                ValidAudience = Audience,//订阅人
                ValidateLifetime = true,  //是否验证生命周期
                ClockSkew = TimeSpan.FromSeconds(30),  //允许服务器时间偏移量30秒，即我们配置的过期时间加上这个允许偏移的时间值，才是真正过期的时间(过期时间 +偏移值)
                RequireExpirationTime = true, //是否要求Token的Claims中必须包含Expires
            };

            //2.1【认证】、core自带官方JWT认证
            // 开启Bearer认证
            services.AddAuthentication("Bearer")
             // 添加JwtBearer服务
             .AddJwtBearer(o =>
             {
                 o.TokenValidationParameters = tokenValidationParameters;
                 o.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         // 如果过期，则把<是否过期>添加到，返回头信息中
                         if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                         {
                             context.Response.Headers.Add("Token-Expired", "true");
                         }
                         return Task.CompletedTask;
                     }
                 };
             });
        }

    }
}
