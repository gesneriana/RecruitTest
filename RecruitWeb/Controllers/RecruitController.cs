using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecruitWeb.Token;
using RecruitWeb.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Recruit.Models;
using Common;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecruitWeb.Controllers
{
    /// <summary>
    /// 用户填写测试题的控制器, 必须登录用户才能访问
    /// </summary>
    [Token(role = "user")]
    [Route("api/[controller]/[action]/{id?}")]
    public class RecruitController : BaseController
    {

        RecruitDbContext dbContext;

        public RecruitController(RecruitDbContext db)
        {
            dbContext = db;
        }

        /// <summary>
        /// 分页显示当前所有的公司列表
        /// </summary>
        /// <returns></returns>
        [ResponseCache(VaryByHeader = "Accept-Encoding", Location = ResponseCacheLocation.Any, Duration = 10)]
        public IActionResult get_company_list(int page = 1)
        {
            ErrorRequestData err = null;
            if (page < 1)
            {
                err = new ErrorRequestData() { HttpStatusCode = 401, ErrorMessage = nameof(page) + "参数错误" };
                return new ContentResult() { Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType, StatusCode = err.HttpStatusCode };
            }

            try
            {
                var p = new EFPaging<recruit_user>();   // 查询公司数据
                var q = dbContext.recruit_user.Where(x => x.auth_role.Equals("company")).OrderBy(x => x.addtime);
                var temp = p.getPageList(q, "/api/Recruit/get_company_list", page);
                var pages = p.pageAjaxHref;

                List<object> list = new List<object>();
                temp.ForEach(x =>
                {
                    var a = new
                    {
                        x.company_address,
                        x.company_code,
                        x.company_contact,
                        x.company_name,
                        x.uuid,
                        jobs = dbContext.job_type.Where(m => m.user_id.Equals(x.uuid) && m.is_enabled == true)
                        .Select(t => new { t.uuid, t.job_name }).ToList(),
                        job_id = string.Empty   // 绑定下拉框的字段, 占位用的
                    };
                    list.Add(a);
                });

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
        /// 获取测试题数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult get_exam_by_job_id(string id)
        {
            ErrorRequestData err = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                err = new ErrorRequestData() { HttpStatusCode = 401, ErrorMessage = nameof(id) + "参数错误" };
                return new ContentResult() { Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType, StatusCode = err.HttpStatusCode };
            }

            try
            {
                var list = dbContext.exam_data.Where(x => x.job_id.Equals(id) && x.is_enabled == true).OrderBy(x => x.exam_type)
                    .Select(x => new
                    {
                        x.anwser_a,
                        x.anwser_b,
                        x.anwser_c,
                        x.anwser_d,
                        x.exam_content,
                        x.exam_type,
                        exam_eq_answer = "",
                        x.id
                    }).ToList();
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

        public IActionResult search_company_list(string com_type, string keywords, int page = 1)
        {
            ErrorRequestData err = null;
            if (string.IsNullOrWhiteSpace(com_type) || string.IsNullOrWhiteSpace(keywords))
            {
                err = new ErrorRequestData() { HttpStatusCode = 401, ErrorMessage = nameof(com_type) + "或" + nameof(keywords) + "参数错误" };
                return new ContentResult() { Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType, StatusCode = err.HttpStatusCode };
            }

            try
            {
                List<recruit_user> temp = null;
                var pages = string.Empty;
                var p = new EFPaging<recruit_user>();
                if (com_type.Equals("com_name"))
                {
                    var q = dbContext.recruit_user.Where(x => x.auth_role.Equals("company") && x.company_name.Contains(keywords)).OrderBy(x => x.addtime);
                    temp = p.getPageList(q, string.Format("/api/Recruit/search_company_list?com_type={0}&keywords={1}", com_type, keywords), page);
                    pages = p.pageAjaxHref;
                }
                else if (com_type.Equals("com_code"))
                {
                    var q = dbContext.recruit_user.Where(x => x.auth_role.Equals("company") && x.company_code.Contains(keywords)).OrderBy(x => x.addtime);
                    temp = p.getPageList(q, string.Format("/api/Recruit/search_company_list?com_type={0}&keywords={1}", com_type, keywords), page);
                    pages = p.pageAjaxHref;
                }
                else if (com_type.Equals("com_addr"))
                {
                    var q = dbContext.recruit_user.Where(x => x.auth_role.Equals("company") && x.company_address.Contains(keywords)).OrderBy(x => x.addtime);
                    temp = p.getPageList(q, string.Format("/api/Recruit/search_company_list?com_type={0}&keywords={1}", com_type, keywords), page);
                    pages = p.pageAjaxHref;
                }


                List<object> list = new List<object>();
                temp.ForEach(x =>
                {
                    var a = new
                    {
                        x.company_address,
                        x.company_code,
                        x.company_contact,
                        x.company_name,
                        x.uuid,
                        jobs = dbContext.job_type.Where(m => m.user_id.Equals(x.uuid) && m.is_enabled == true)
                        .Select(t => new { t.uuid, t.job_name }).ToList(),
                        job_id = string.Empty   // 绑定下拉框的字段, 占位用的
                    };
                    list.Add(a);
                });

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
        /// 提交测试题答案
        /// </summary>
        /// <param name="job_id"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public IActionResult submit_exam_data(string job_id, List<user_answer> list)
        {
            ErrorRequestData err = null;
            if (list != null && list.Count > 0 && !string.IsNullOrWhiteSpace(job_id))
            {
                try
                {
                    var score = new user_score() { job_id = job_id, user_id = signedUser.user_uuid };
                    var exam_dict = dbContext.exam_data.Where(x => x.job_id.Equals(job_id)).Select(x => new { x.id, x.exam_type, x.exam_cq_anwser }).ToDictionary(x => x.id);
                    list.ForEach(x =>
                    {
                        if (exam_dict.ContainsKey(x.exam_id))
                        {
                            if (x.exam_type.Equals("cq") && x.exam_answer.Equals(exam_dict[x.exam_id].exam_cq_anwser))
                            {
                                ++score.cq_score;
                            }
                            x.id = UUID.getUUID();
                            x.user_score_id = score.id;
                            dbContext.user_answer.Add(x);
                        }
                    });
                    dbContext.user_score.Add(score);
                    dbContext.SaveChanges();
                    return Content("保存成功");
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
            else
            {
                err = new ErrorRequestData() { HttpStatusCode = 401, ErrorMessage = nameof(job_id) + "或" + nameof(list) + "参数错误" };
                return new ContentResult() { Content = err.toJosnString(), ContentType = ConstantTypeString.JsonContentType, StatusCode = err.HttpStatusCode };
            }
        }

    }
}
