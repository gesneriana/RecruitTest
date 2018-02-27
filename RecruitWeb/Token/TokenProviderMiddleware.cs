using Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RecruitWeb.Token
{

    /// <summary>
    /// token 验证 请求头中间件
    /// </summary>
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;

        public IMemoryCache cahce { get; set; }

        public IAuthenticationSchemeProvider Schemes { get; set; }


        public TokenProviderMiddleware(
            RequestDelegate next,
            IOptions<TokenProviderOptions> options,
            IAuthenticationSchemeProvider schemes,
            IMemoryCache memoryCache
            )
        {
            _next = next;
            _options = options.Value;
            Schemes = schemes;
            cahce = memoryCache;
        }


        /// <summary>
        /// invoke the middleware
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Invoke(HttpContext httpContext)
        {
            //检测是否包含'Authorization'请求头，如果不包含返回context进行下一个中间件，用于访问不需要认证的API
            if (!httpContext.Request.Headers.ContainsKey("Authorization"))
                return _next(httpContext);
            else
            {
                var tokenHeader = httpContext.Request.Headers["Authorization"].ToString();
                try
                {
                    tokenHeader = tokenHeader.Substring("Bearer ".Length).Trim();
                    var result = cahce.GetCacheValue<SignedUser>(tokenHeader);  // 根据token从内存缓存中读取权限, 也可以是redis
                    if (result == null)
                        return httpContext.Response.WriteAsync("BadRequest"); // token过期
                    else
                    {
                        ClaimsIdentity identity = new ClaimsIdentity(result.user_claims);
                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                        httpContext.User = principal;//构建authorize认证
                        return _next(httpContext);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);

                    return httpContext.Response.WriteAsync("token值长度不够");
                }
            }
        }

        /// <summary>
        /// get the jwt
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private string GetJwt(string username)
        {
            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(),ClaimValueTypes.Integer64),
                //用户名
                new Claim(ClaimTypes.Name,username),
                //角色
                new Claim(ClaimTypes.Role,"a")
            };

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                Status = true,
                access_token = encodedJwt,
                expires_in = (int)_options.Expiration.TotalSeconds,
                token_type = "Bearer"
            };
            return JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

    }
}
