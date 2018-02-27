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

namespace RecruitWeb.Controllers
{
    /// <summary>
    /// 用户账户控制器, 颁发token, 登录, 注销, 权限授予的功能
    /// </summary>
    [Route("api/[controller]/[action]/{id?}")]
    public class AccountController : Controller
    {

        RecruitDbContext dbContext;
        IMemoryCache memoryCache;

        public AccountController(RecruitDbContext dbContext, IMemoryCache cache)
        {
            this.dbContext = dbContext;
            memoryCache = cache;
        }

        [HttpPost]
        public IActionResult Login([FromForm]string uname, [FromForm]string pwd)
        {
            if (string.IsNullOrWhiteSpace(uname) || string.IsNullOrEmpty(pwd))
            {
                HttpContext.Response.StatusCode = 400;
                return Json("参数错误");
            }

            var user = dbContext.recruit_user.Where(x => (x.nickname.Equals(uname) || x.email.Equals(uname) || x.phone.Equals(uname)) && x.pwd.Equals(Sha1.getSha1String(pwd))).FirstOrDefault();
            if (user == null)
            {
                HttpContext.Response.StatusCode = 400;
                return Json("用户或者密码错误");
            }
            else
            {
                var date = DateTime.UtcNow;
                Claim[] claims = new Claim[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, "test"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, date.ToString(), ClaimValueTypes.Integer64),
                };

                JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: "Asuna",
                audience: user.phone,
                claims: claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Asuna2yhciUyMHdvbmclMFWfsaZlJTIwLm5ldA==")), SecurityAlgorithms.HmacSha256)
                );
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                var response = new
                {
                    access_token = encodedJwt,
                    expires_in = 24,    // 24小时
                    token_type = "Bearer"
                };

                var userClaims = new List<Claim>() { new Claim("role", user.role) };    // 权限可以有多个, 保存在数据库用户表中
                memoryCache.SetChacheValue(encodedJwt, new SignedUser() { user_token = encodedJwt, user_phone = user.phone, user_claims = userClaims });   // 将用户token保存到内存缓存

                return Json(response);
            }
        }

        [Authorize("test")]
        public IActionResult CheckToken()
        {
            return Content("请求成功");
        }
    }
}