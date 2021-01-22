using EInfrastructure.Core.Serialize.NewtonsoftJson;
using Microsoft.AspNetCore.Mvc;
using Movies.Domin;
using Movies.Infrastructure;
using Newtonsoft.Json;

namespace Movies.Controllers
{
    [Route("api/movies/base/[action]")]
    public class BaseController : Controller
    {
        /// <summary>
        /// Post请求返回json
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected JsonResult PostJson(object data = null)
        {
            //if (data == null)
            //{
            //    data = new
            //    {
            //        Success = false
            //    };
            //}

            //var result = new ApiResult(200, data);

            return base.Json(new { code = 200, data = data }, new JsonSerializerSettings()
            {
                ContractResolver = new NullToEmptyStringResolver(),//为空时，序列化或反序列化成其他值（成空字符串）
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,//时间误差
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,//忽视
                DateFormatString = "yyyy-MM-dd HH:mm:ss"//时间格式化
            });
        }

        /// <summary>
        /// 账户
        /// </summary>
        protected string AccountId
        {
            get
            {
                string tokenStr = HttpContext.Request.Headers["UserAuthorization"].ToString();//取header值
                string key = "125/*/o56asdddd7d8d4d5d6d490****";
                //var token = context.HttpContext.Request.Cookies["Token"];前后端分离不能用cookie,要用Headers
                var decrypt = Tools.Decrypt(tokenStr, key);
                var toSequence = JsonConvert.DeserializeObject<AdminAccount>(decrypt);
                return toSequence.Id;
            }
        }
    }
}
