using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Recruit.Models;
using RecruitWeb.Models;
using RecruitWeb.Token;

namespace RecruitWeb.Controllers
{
    /// <summary>
    /// 必须登录, 并且有公司的权限才能访问
    /// </summary>
    [Token(role = "company")]
    [Route("api/[controller]/[action]/{id?}")]
    public class CompanyController : BaseController
    {
        RecruitDbContext dbContext;

        public CompanyController(RecruitDbContext db)
        {
            dbContext = db;
        }

        /// <summary>
        /// 添加岗位类型, 也就是试题类型
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddJobType(string job_name)
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
    }
}