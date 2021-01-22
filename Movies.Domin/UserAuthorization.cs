using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Movies.Domin;
using Newtonsoft.Json;
using System;
using System.Linq;
using IAuthorizationFilter = Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter;

namespace Movies.Infrastructure
{
    /// <summary>
    ///  授权自定义过滤
    /// </summary>
    public class UserAuthorization : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //控制器头（写 [Film.Extension.UserAuthorization2]）验证下某个方法不验证（方法头上写[AllowAnonymous]）
            if (((ControllerActionDescriptor)context.ActionDescriptor).MethodInfo.GetCustomAttributes(inherit: true).Any(a => a.GetType().Equals(typeof(AllowAnonymousAttribute))))
            {
                return;
            }
            //context.HttpContext.Request.Cookies
            var id = "";
            //上下文的HttpContext里面有Request
            if (context.HttpContext.Request.Headers.Any(x=>x.Key== "UserAuthorization"))
            {
                string tokenStr = context.HttpContext.Request.Headers["UserAuthorization"].ToString();//取header值
                string key = "125/*/o56asdddd7d8d4d5d6d490****";
                //var token = context.HttpContext.Request.Cookies["Token"];前后端分离不能用cookie,要用Headers
                var decrypt = Tools.Decrypt(tokenStr, key);
                var toSequence = JsonConvert.DeserializeObject<AdminAccount>(decrypt);

                id = toSequence.Id;
            }
            if (string.IsNullOrWhiteSpace(id))
            {
                context.HttpContext.Response.StatusCode = 401;
                var res = new
                {
                    code = 401,
                    msg = "权限不足"
                };
                context.Result = new JsonResult(res);
                return ;
            }
        }
    }
}
