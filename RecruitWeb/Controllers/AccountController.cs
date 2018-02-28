using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recruit.Models;
using Common;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using RecruitWeb.Token;
using Microsoft.AspNetCore.Authorization;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.Extensions.Configuration;
using RecruitWeb.Configuration;
using Microsoft.Extensions.Options;
using RecruitWeb.Models;

namespace RecruitWeb.Controllers
{
    /// <summary>
    /// 用户账户控制器, 颁发token, 登录, 注销, 权限授予的功能
    /// </summary>
    [Route("api/[controller]/[action]/{id?}")]
    public class AccountController : BaseController
    {

        RecruitDbContext dbContext;

        static JwtTokenConfig jwtTokenConfig;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="cache"></param>
        /// <param name="jwtConfig"></param>
        public AccountController(RecruitDbContext dbContext, IOptions<JwtTokenConfig> jwtConfig)
        {
            this.dbContext = dbContext;
            jwtTokenConfig = jwtConfig.Value;
        }

        [HttpPost]
        public IActionResult Login([FromForm]string uname, [FromForm]string pwd)
        {
            var err = new ErrorRequestData();
            err.Description = HttpContext.Request.GetAbsoluteUri();

            if (string.IsNullOrWhiteSpace(uname) || string.IsNullOrEmpty(pwd))
            {
                err.HttpStatusCode = 401;
                err.ErrorType = ConstantTypeString.TokenError;
                err.ErrorMessage = "参数错误";
                return new ContentResult() { StatusCode = err.HttpStatusCode, Content = err.toJosnString(), ContentType = ConstantTypeString.ContentType };
            }

            var user = dbContext.recruit_user.Where(x => (x.nickname.Equals(uname) || x.email.Equals(uname) || x.phone.Equals(uname)) && x.pwd.Equals(Sha1.getSha1String(pwd))).FirstOrDefault();
            if (user == null)
            {
                err.HttpStatusCode = 403;
                err.ErrorType = ConstantTypeString.TokenError;
                err.ErrorMessage = "用户或者密码错误";
                return new ContentResult() { StatusCode = err.HttpStatusCode, Content = err.toJosnString(), ContentType = ConstantTypeString.ContentType };
            }

            try
            {
                var guid = Guid.NewGuid().ToString();   // 唯一标识

                var payload = new Dictionary<string, object>()
                    {
                        { "jti", guid}
                    };

                string secret = jwtTokenConfig.Secret;
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

                var jwtToken = encoder.Encode(payload, secret);  // 生成jwtToken
                DateTime utcNow = DateTime.UtcNow;

                // 可以添加多个role , 但是role type 必须相同, 如果是正式的产品, 这里需要单独提取一张权限表, 仅做测试阶段使用
                var userClaims = new List<Claim>();
                if (user.role.Equals("admin"))
                {
                    userClaims.Add(new Claim(nameof(TokenAttribute.role), user.role));
                    userClaims.Add(new Claim(nameof(TokenAttribute.role), "user"));
                    userClaims.Add(new Claim(nameof(TokenAttribute.role), "company"));
                }
                else if (user.role.Equals("company"))
                {
                    userClaims.Add(new Claim(nameof(TokenAttribute.role), user.role));
                    userClaims.Add(new Claim(nameof(TokenAttribute.role), "user"));
                }
                else
                {
                    userClaims.Add(new Claim(nameof(TokenAttribute.role), user.role));
                }

                // 将用户token保存到内存缓存
                MemoryCacheService.SetChacheValue(guid,
                    new SignedUser()
                    {
                        guid = guid,
                        Audience = jwtTokenConfig.Audience,
                        Issuer = jwtTokenConfig.Issuer,
                        utc_time = utcNow,
                        user_token = jwtToken,
                        user_phone = user.phone,
                        user_claims = userClaims,
                        Validity = jwtTokenConfig.Validity,
                        TokenType = jwtTokenConfig.TokenType
                    });

                // 将token写入响应流中
                var response = new { token = jwtToken, expires_in = jwtTokenConfig.Validity, token_type = jwtTokenConfig.TokenType };
                return Json(response);
            }
            catch (Exception ex)
            {
                err.HttpStatusCode = 500;
                err.ErrorType = ConstantTypeString.TokenError;
                err.ErrorMessage = ex.Message;
                return new ContentResult() { StatusCode = err.HttpStatusCode, Content = err.toJosnString(), ContentType = ConstantTypeString.ContentType };
            }
        }

        [Token(role = "user")]
        public IActionResult CheckToken()
        {
            return Content("请求成功");
        }
    }
}