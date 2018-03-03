using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitWeb.Models
{

    /// <summary>
    /// 预定义的常量类型
    /// </summary>
    public class ConstantTypeString
    {
        /// <summary>
        /// 普通的错误
        /// </summary>
        public const string NormalError = "NormalError";

        /// <summary>
        /// token不正确
        /// </summary>
        public const string TokenError = "TokenError";

        /// <summary>
        /// 权限不够
        /// </summary>
        public const string UnAuthorization = "UnAuthorization";

        /// <summary>
        /// 400系列的错误
        /// </summary>
        public const string NotFound = "NotFound";

        /// <summary>
        /// 500系列的异常
        /// </summary>
        public const string Exceprion = "Exceprion";

        /// <summary>
        /// http 响应头的类型
        /// </summary>
        public const string JsonContentType = "application/json";

        /// <summary>
        /// html 页面的 ContentType
        /// </summary>
        public const string TextHtmlContentType = "text/html";
    }

    /// <summary>
    /// 保存错误请求的数据, json序列号返回到 vue中解析
    /// </summary>
    public class ErrorRequestData
    {
        /// <summary>
        /// 自定义的http状态码,默认设置为400, 错误码都大于 400 
        /// </summary>
        public int HttpStatusCode { get; set; } = 400;

        /// <summary>
        /// 错误类型,默认为NormalError
        /// 其他的类型例如 TokenInvalid, Exception,  Unauthorized
        /// </summary>
        public string ErrorType { get; set; } = ConstantTypeString.NormalError;

        /// <summary>
        /// 是否显示弹窗口提示错误信息, 默认为true
        /// </summary>
        public bool ShowMsgBox { get; set; } = true;

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; } = string.Empty;

        /// <summary>
        /// 描述, 默认为空字符串
        /// </summary>
        public string Description { get; set; } = string.Empty;

        public string toJosnString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
