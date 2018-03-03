using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Recruit.Models;
using RecruitWeb.Models;
using RecruitWeb.Token;

namespace RecruitWeb.Controllers
{
    public class HomeController : BaseController
    {

        RecruitDbContext dbContext;

        public HomeController(RecruitDbContext db)
        {
            dbContext = db;
        }

        /// <summary>
        /// 默认的首页, 应该验证token, 未登录提示登录,
        /// 已登录则根据role判断用户身份, 面试者必填字段验证
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // 重定向到vue.js的首页
            return Redirect("/app/index.html");
        }

        /// <summary>
        /// 添加岗位类型, 也就是试题类型
        /// </summary>
        /// <returns></returns>
        [Token(role = "company")]
        [HttpPost]
        public IActionResult AddJonType(string job_name)
        {
            ErrorRequestData err = null;
            if (string.IsNullOrWhiteSpace(job_name))
            {
                err = new ErrorRequestData() { HttpStatusCode = 401, ErrorMessage = "参数错误" };
                return new ContentResult() { StatusCode = err.HttpStatusCode, Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType };
            }
            try
            {
                job_type jt = new job_type() { job_name = job_name, addtime = DateTime.Now, user_id = signedUser.user_uuid, uuid = UUID.getUUID() };
                dbContext.job_type.Add(jt);
                dbContext.SaveChanges();
                return Content("添加成功");
            }
            catch (DbUpdateException dbex)
            {
                if (dbex.InnerException is PostgresException npge)
                {
                    err = new ErrorRequestData() { HttpStatusCode = 500, ErrorMessage = npge.Detail };
                }
                else
                {
                    err = new ErrorRequestData() { HttpStatusCode = 500, ErrorMessage = dbex.Message };
                }
                return new ContentResult() { StatusCode = err.HttpStatusCode, Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType };
            }
            catch (Exception ex)
            {
                err = new ErrorRequestData() { HttpStatusCode = 500, ErrorMessage = ex.Message };
                return new ContentResult() { StatusCode = err.HttpStatusCode, Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType };
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
