using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecruitWeb.Token;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecruitWeb.Controllers
{

    /// <summary>
    /// 自定义的控制器基类, 方便代码重用
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 登录的用户, 保存token权限等信息
        /// 如果不继承此控制器, 从 ViewData["signedUser"] 中取登录用户数据
        /// </summary>
        public SignedUser signedUser { get; set; }
    }
}
