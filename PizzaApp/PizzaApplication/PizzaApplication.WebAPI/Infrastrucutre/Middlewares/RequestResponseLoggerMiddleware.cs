using System.Text;
using PizzaApplication.WebAPI.Infrastrucutre.Extensions;


namespace PizzaApplication.WebAPI.Infrastrucutre.Middlewares
{
    public class RequestResponseLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WebApplicationBuilder _builder;
        public RequestResponseLoggerMiddleware(RequestDelegate next , WebApplicationBuilder builder)
        {
            this._next = next;
            this._builder = builder;
        }

        public async Task Invoke(HttpContext context)
        {
            await LogRequest(context);
            await this._next.Invoke(context);
            //await LogResponse(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            context.Request.EnableBuffering();
            string Logtxt;
            string body = string.Empty;

            if (context.Request.Body.CanRead)
            {
                using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8))
                {
                    body = await reader.ReadToEndAsync();
                    context.Request.Body.Position = 0;
                }
            }
            Logtxt = $"Request: \n"+
                $"ip: {context.Request.HttpContext.Connection.RemoteIpAddress.ToString()} \n" +
                $"time: {DateTime.Now}\n" +
                $"body: \n" +
                $"{body}\n" +
                $"Querry: {context.Request.QueryString}\n" +
                $"path : {context.Request.Path} \n" +
                "-----------------------------------------";
            await this._builder.LogInformationAsync(Logtxt);
        }


        private async Task LogResponse(HttpContext context)
        {
            string data = string.Empty;
            using(StreamReader reader = new StreamReader(context.Response.Body , Encoding.UTF8))
            {
                data = await reader.ReadToEndAsync();
            }
            Console.WriteLine(data);
        }



    }
}
