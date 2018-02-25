using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecruitWeb.Models;

namespace RecruitWeb.Controllers
{
    public class HomeController : Controller
    {
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
