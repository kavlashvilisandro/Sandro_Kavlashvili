using EventsItAcademyGe.Domain.Exceptions;
using System.Text.Json;

namespace EventsItAcademyGe.WebAPI.Infrastructure.Middlewares
{
    public class GlobalErrorHandlerMiddleware
    {
        private readonly Serilog.ILogger _logger;
        private readonly RequestDelegate _next;

        public GlobalErrorHandlerMiddleware(RequestDelegate next, Serilog.ILogger logger)
        {
            this._logger = logger;
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string bodyTXT = "";
            Exception exception = null;
            try
            {
                await _next.Invoke(context);
            }
            catch (CustomException ex)
            {
                Dictionary<string,object> body = new Dictionary<string, object>()
                {
                    { "StatusCode",ex.GetStatusCode()},
                    { "Error" , ex.Message}
                };
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex.GetStatusCode();
                bodyTXT = JsonSerializer.Serialize(body);
                await context.Response.WriteAsync(bodyTXT);

            }catch (Exception ex)
            {
                Dictionary<string, object> body = new Dictionary<string, object>()
                {
                    { "StatusCode",500 },
                    { "Error" , ex.Message }
                };
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
                bodyTXT = JsonSerializer.Serialize(body);
                await context.Response.WriteAsync(bodyTXT);
                exception = ex;
            }
            finally
            {
                if(exception != null)
                {
                    _logger.Error(exception.GetType().ToString() + " -- "
                        + exception.StackTrace.Replace("\n", "\n        "));
                }
            }
        }

    }
}
