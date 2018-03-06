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
                var p = new EFPaging<recruit_user>();
                var q = dbContext.recruit_user.Where(x => x.auth_role.Equals("company")).OrderBy(x => x.addtime);
                var temp = p.getPageList(q, "/api/company/get_exam_data?page=", page);
                var pages = p.pageAjaxHref;

                List<object> list = new List<object>();
                temp.ForEach(x =>
                {
                    var a = new { x.company_address, x.company_code, x.company_contact, x.company_name, x.uuid };
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
    }
}
