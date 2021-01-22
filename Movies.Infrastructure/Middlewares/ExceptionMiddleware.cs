using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Middlewares
{
    //中间件（捕捉异常）
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //await next(context);
            try
            {
                await next.Invoke(context);
                var features = context.Features;
            }
            catch (Exception e)
            {

                await HandleException(context, e);
            }
        }

        private async Task HandleException(HttpContext context, Exception e)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "text/json;charset=utf-8;";
            string error = "";


            var obj = new { message = e.Message };
            error = JsonConvert.SerializeObject(obj);


            await context.Response.WriteAsync(error);
        }
    }
}
