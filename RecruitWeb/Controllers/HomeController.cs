using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecruitWeb.Models;

namespace RecruitWeb.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 默认的首页, 应该验证token, 未登录提示登录,
        /// 已登录则根据role判断用户身份, 面试者必填字段验证
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // 重定向到vue.js的首页
            return Redirect("/app/index.html");
            // return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
