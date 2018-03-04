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
                var list = dbContext.job_type.Where(x => x.user_id.Equals(signedUser.user_uuid)).ToList();
                return Json(list);
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

        /// <summary>
        /// 获取所有的岗位列表
        /// </summary>
        /// <returns></returns>
        public IActionResult get_job_names()
        {
            var list = dbContext.job_type.Where(x => x.user_id.Equals(signedUser.user_uuid)).OrderBy(x => x.is_enabled).ToList();
            return Json(list);
        }


        /// <summary>
        /// 修改岗位的状态
        /// </summary>
        /// <param name="id">job_type 表的key</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult change_job_state(string id, bool state = true)
        {
            ErrorRequestData err = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                err = new ErrorRequestData() { HttpStatusCode = 401, ErrorMessage = nameof(id) + "参数错误" };
                return new ContentResult() { Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType, StatusCode = err.HttpStatusCode };
            }

            try
            {
                var jobtype = dbContext.job_type.Where(x => x.uuid.Equals(id)).FirstOrDefault();
                if (jobtype != null && jobtype.user_id.Equals(signedUser.user_uuid))
                {
                    jobtype.is_enabled = state;
                    dbContext.SaveChanges();
                    return Content("修改成功");
                }
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
            return Content("修改失败");
        }

        /// <summary>
        /// 删除岗位名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult delate_job_type(string id)
        {
            ErrorRequestData err = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                err = new ErrorRequestData() { HttpStatusCode = 401, ErrorMessage = nameof(id) + "参数错误" };
                return new ContentResult() { Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType, StatusCode = err.HttpStatusCode };
            }

            try
            {
                var j = dbContext.job_type.Where(x => x.uuid.Equals(id)).FirstOrDefault();
                if (j != null && signedUser.user_uuid.Equals(j.user_id))
                {
                    var ent = dbContext.Entry(j);
                    ent.State = EntityState.Deleted;
                    dbContext.SaveChanges();
                    return Content("ok");
                }
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
            return Content("删除失败");
        }
    }
}