using System.Text.Json;
using ToDoAPI.WebAPI.Logs;

namespace ToDoAPI.WebAPI.Infrastructure.Middlewares
{
    public class GlobalErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogService _logger;
        public GlobalErrorHandlerMiddleware(RequestDelegate next, ILogService logger)
        {
            this._logger = logger;
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }catch (Exception ex)
            {
                await HandleError(ex, context);
            }
        }


        public async Task HandleError(Exception ex, HttpContext context)
        {
            string result = JsonSerializer.Serialize(new
            {
                error = ex.Message,
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;
            Console.ForegroundColor = ConsoleColor.Red;
            await context.Response.WriteAsync(result);
            _logger.LogError(ex);
        }



    }
}
