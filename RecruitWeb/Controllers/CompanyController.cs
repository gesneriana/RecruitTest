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
using RecruitWeb.Models.ViewModel;
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
            ErrorRequestData err = null;
            try
            {
                var list = dbContext.job_type.Where(x => x.user_id.Equals(signedUser.user_uuid)).OrderByDescending(x => x.is_enabled).ToList();
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
        public IActionResult delete_job_type(string id)
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

        /// <summary>
        /// 添加试题数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult add_exam_data(exam_data model)
        {
            ErrorRequestData err = null;
            if (model == null)
            {
                err = new ErrorRequestData() { HttpStatusCode = 401, ErrorMessage = nameof(model) + "参数错误" };
                return new ContentResult() { Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType, StatusCode = err.HttpStatusCode };
            }

            if ("cq".Equals(model.exam_type))
            {
                if (string.IsNullOrWhiteSpace(model.exam_content)
                    || string.IsNullOrWhiteSpace(model.exam_cq_anwser)
                    || string.IsNullOrWhiteSpace(model.anwser_a)
                    || string.IsNullOrWhiteSpace(model.anwser_b)
                    || string.IsNullOrWhiteSpace(model.anwser_c)
                    || string.IsNullOrWhiteSpace(model.anwser_d))
                {
                    err = new ErrorRequestData() { HttpStatusCode = 401, ErrorMessage = nameof(model) + "参数错误" };
                    return new ContentResult() { Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType, StatusCode = err.HttpStatusCode };
                }
                model.exam_eq_answer = string.Empty;
            }
            else if ("eq".Equals(model.exam_type))
            {
                if (string.IsNullOrWhiteSpace(model.exam_content) || string.IsNullOrWhiteSpace(model.exam_eq_answer))
                {
                    err = new ErrorRequestData() { HttpStatusCode = 401, ErrorMessage = nameof(model) + "参数错误" };
                    return new ContentResult() { Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType, StatusCode = err.HttpStatusCode };
                }
                model.exam_cq_anwser = string.Empty;
                model.anwser_a = string.Empty;
                model.anwser_b = string.Empty;
                model.anwser_c = string.Empty;
                model.anwser_d = string.Empty;
            }
            try
            {
                model.user_id = signedUser.user_uuid;
                dbContext.exam_data.Add(model);
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

        /// <summary>
        /// 分页显示测试题
        /// </summary>
        /// <param name="job_id"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public IActionResult get_exam_data(string job_id, int page = 1)
        {
            ErrorRequestData err = null;
            if (string.IsNullOrWhiteSpace(job_id) || page < 1)
            {
                err = new ErrorRequestData() { HttpStatusCode = 401, ErrorMessage = nameof(job_id) + "或者" + nameof(page) + "参数错误" };
                return new ContentResult() { Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType, StatusCode = err.HttpStatusCode };
            }

            try
            {
                var p = new EFPaging<exam_data>();
                var q = dbContext.exam_data.Where(x => x.job_id.Equals(job_id) && x.user_id.Equals(signedUser.user_uuid)).OrderByDescending(x => x.is_enabled).OrderBy(x => x.exam_type);
                var list = p.getPageList(q, "/api/company/get_exam_data?job_id=" + job_id, page);
                var pages = p.pageAjaxHref;

                return Json(new { list, pages });
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
        /// 禁用一条试题记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult disable_exam(string id, bool state = true)
        {
            ErrorRequestData err = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                err = new ErrorRequestData() { HttpStatusCode = 401, ErrorMessage = nameof(id) + "或者参数错误" };
                return new ContentResult() { Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType, StatusCode = err.HttpStatusCode };
            }

            try
            {
                var exam = dbContext.exam_data.Where(x => x.id.Equals(id) && x.user_id.Equals(signedUser.user_uuid)).FirstOrDefault();
                if (exam != null)
                {
                    exam.is_enabled = state;
                }
                dbContext.SaveChanges();
                return Content("修改成功");
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
        /// 根据岗位id查找 用户的测试题答案
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult get_user_answer(string id, int page = 1)
        {
            ErrorRequestData err = null;
            if (string.IsNullOrWhiteSpace(id) || page < 1)
            {
                err = new ErrorRequestData() { HttpStatusCode = 401, ErrorMessage = nameof(id) + "或者参数错误" };
                return new ContentResult() { Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType, StatusCode = err.HttpStatusCode };
            }

            try
            {
                var q = from s in dbContext.user_score
                        join u in dbContext.recruit_user on s.user_id equals u.uuid
                        where s.job_id == id
                        select new user_score_info
                        {
                            uname = u.uname,
                            cq_score = s.cq_score,
                            eq_score = s.eq_score,
                            invitation_code = s.invitation_code,
                            addtime = s.addtime,
                            phone = u.phone,
                            email = u.email,
                            id = s.id
                        };
                var p = new EFPaging<user_score_info>();    // 需要定义视图模型
                var list = p.getPageList(q, "/api/company/get_user_answer/" + id, page);
                var pages = p.pageAjaxHref;
                return Json(new { list, pages });
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
        /// 根据 user_score 的id获取 user_answer 所有答题的记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult get_user_answer_by_id(string id)
        {
            ErrorRequestData err = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                err = new ErrorRequestData() { HttpStatusCode = 401, ErrorMessage = nameof(id) + "或者参数错误" };
                return new ContentResult() { Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType, StatusCode = err.HttpStatusCode };
            }

            try
            {
                // 此处应改为联合查询, 加载测试题的数据
                var list = from a in dbContext.user_answer
                           join e in dbContext.exam_data on a.exam_id equals e.id
                           where a.user_score_id.Equals(id)
                           orderby e.exam_type
                           select new
                           {
                               a.id,
                               a.addtime,
                               a.exam_answer,
                               a.exam_type,
                               e.exam_content,
                               e.exam_cq_anwser,
                               e.exam_eq_answer
                           };
                return Json(list.ToList());
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
        /// 设置用户的笔试题分数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public IActionResult set_user_score(string id, int score = 0)
        {
            ErrorRequestData err = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                err = new ErrorRequestData() { HttpStatusCode = 401, ErrorMessage = nameof(id) + "或者参数错误" };
                return new ContentResult() { Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType, StatusCode = err.HttpStatusCode };
            }

            try
            {
                var m = dbContext.user_score.Where(x => x.id.Equals(id)).FirstOrDefault();
                if (m != null)
                {
                    m.eq_score = score;
                    dbContext.SaveChanges();
                }
                return Content("设置成功");
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
        /// 设置邀请码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult set_invitation_code(string id)
        {
            ErrorRequestData err = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                err = new ErrorRequestData() { HttpStatusCode = 401, ErrorMessage = nameof(id) + "或者参数错误" };
                return new ContentResult() { Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType, StatusCode = err.HttpStatusCode };
            }

            try
            {
                var m = dbContext.user_score.Where(x => x.id.Equals(id)).FirstOrDefault();
                if (m != null)
                {
                    if (string.IsNullOrWhiteSpace(m.invitation_code))
                    {
                        m.invitation_code = Guid.NewGuid().ToString("D").Replace("-", "").Substring(0, 8).ToUpper();
                    }
                    else
                    {
                        m.invitation_code = string.Empty;
                    }
                    dbContext.SaveChanges();
                    return Json(new { result = true, message = m.invitation_code });
                }
                return Json(new { result = false, message = "设置邀请码失败" });
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