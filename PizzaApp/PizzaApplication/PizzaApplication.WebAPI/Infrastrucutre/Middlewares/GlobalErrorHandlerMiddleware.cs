using System.Text.Json;
using PizzaApplication.WebAPI.Infrastrucutre.Extensions;

namespace PizzaApplication.WebAPI.Infrastrucutre.Middlewares
{
    public class GlobalErrorHandlerMiddleware
    {
        private RequestDelegate _next;
        private WebApplicationBuilder _builder;
        public GlobalErrorHandlerMiddleware(RequestDelegate next , WebApplicationBuilder builder)
        {
            this._next = next;

        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }catch (Exception ex)
            {
                await ErrorHandler(ex , context);    
            }
        }

        public async Task ErrorHandler(Exception ex , HttpContext context)
        {
            string body = JsonSerializer.Serialize(new
            {
                Error = "There is error",
                Time = DateTime.Now,
            });
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(body);
            Task res = _builder.LogErrorAsync(ex.StackTrace + "\n" +
                "-------------------------------------");
            Console.WriteLine(ex.StackTrace + "\n" +
                "-------------------------------------");
            await res;
        }
    }
}
