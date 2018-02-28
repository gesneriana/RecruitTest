using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RecruitWeb.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}