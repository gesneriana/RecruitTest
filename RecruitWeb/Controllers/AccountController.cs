using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RecruitWeb.Controllers
{
    /// <summary>
    /// 用户账户控制器, 颁发token, 登录, 注销, 权限授予的功能
    /// </summary>
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}