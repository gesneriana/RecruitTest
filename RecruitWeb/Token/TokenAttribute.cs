using Common;
using JWT;
using JWT.Serializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using RecruitWeb.Configuration;
using RecruitWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RecruitWeb.Token
{
    /// <summary>
    /// 在请求到达action方法之前验证， 可以中断后面的流程， 返回http状态码和响应流
    /// 验证token的权限以及是否过期
    /// </summary>
    public class TokenAttribute : ActionFilterAttribute
    {

        /// <summary>
        /// 权限规则, 访问某个action所需要的权限, 
        /// 一个用户可以有多个权限, 但只需要满足这一个就可以了
        /// </summary>
        public string role { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("token_type"))
            {
                context.Result = new ContentResult() { StatusCode = 401, Content = "token_type_invalid" };
            }
            if (!context.HttpContext.Request.Headers.ContainsKey("token"))
            {
                context.Result = new ContentResult() { StatusCode = 401, Content = "token_invalid" };
            }


            // 只有通过验证才能继续执行， 否则返回错误信息
            if (context.HttpContext.Request.Headers["token_type"].ToString().Equals(Config.configuration["JwtTokenConfig:TokenType"]))
            {
                if (context.HttpContext.Request.Headers.ContainsKey("token"))
                {
                    var token = context.HttpContext.Request.Headers["token"].ToString();    // 请求头的token

                    try
                    {
                        IJsonSerializer serializer = new JsonNetSerializer();
                        IDateTimeProvider provider = new UtcDateTimeProvider();
                        IJwtValidator validator = new JwtValidator(serializer, provider);
                        IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                        IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                        var claims = decoder.DecodeToObject<Dictionary<string, object>>(token, Config.configuration["JwtTokenConfig:Secret"], true);
                        if (claims != null)
                        {
                            // 根据token获取 guid 查找内存缓存中的用户信息
                            if (claims.ContainsKey("jti"))
                            {
                                var guid = claims["jti"].ToString();

                                if (Config.cache != null)
                                {
                                    var su = MemoryCacheService.GetCacheValue<SignedUser>(guid);
                                    if (su != null)
                                    {
                                        // 验证是否过期
                                        if (su.utc_time.AddHours(su.Validity) > DateTime.UtcNow)
                                        {
                                            Console.WriteLine("token过期");
                                            context.Result = new ContentResult() { StatusCode = 401, Content = "token过期" };
                                            return;
                                        }

                                        // 验证权限
                                        if (su.user_claims.Where(x => x.Type.Equals(nameof(role)) && x.Value.Equals(role)).Count() > 0)
                                        {
                                            // 将 user 写入本次请求数据, 也可以保存在 ViewBag中
                                            if (context.Controller is BaseController baseController)
                                            {
                                                baseController.signedUser = su;
                                            }
                                            else
                                            {
                                                // 没有继承与基类则保存到本次请求上下文中, 需要自己手动进行类型转换
                                                var controller = context.Controller as Controller;
                                                controller.ViewData["signedUser"] = su;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("你没有所需的权限");
                                            context.Result = new ContentResult() { StatusCode = 403, Content = "你没有所需的权限" };
                                            return;
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("你的token可能已经失效");
                                        context.Result = new ContentResult() { StatusCode = 401, Content = "tokenInvalid" };
                                        return;
                                    }
                                }
                                else if (Config.cache == null)
                                {
                                    Console.WriteLine(context.HttpContext.Request.GetAbsoluteUri());
                                    context.Result = new ContentResult() { StatusCode = 401, Content = "缓存服务未初始化" };
                                    return;
                                }
                            }
                            else
                            {
                                Console.WriteLine(context.HttpContext.Request.GetAbsoluteUri());
                                context.Result = new ContentResult() { StatusCode = 401, Content = "token中不包含jti" };
                                return;
                            }

                        }
                    }
                    catch (SignatureVerificationException)
                    {
                        context.Result = new ContentResult() { StatusCode = 401, Content = "token签名验证失败" };
                        return;
                    }
                    catch (Exception ex)
                    {
                        context.Result = new ContentResult() { StatusCode = 401, Content = ex.Message };
                        return;
                    }

                }
            }
            else
            {
                context.Result = new ContentResult() { Content = "你的token类型不正确", StatusCode = 401 };
            }
            base.OnActionExecuting(context);
        }
    }
}
