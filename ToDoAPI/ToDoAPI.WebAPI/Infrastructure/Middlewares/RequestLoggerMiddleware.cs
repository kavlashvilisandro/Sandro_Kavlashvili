using ToDoAPI.WebAPI.Logs;

namespace ToDoAPI.WebAPI.Infrastructure.Middlewares
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogService _logService;
        public RequestLoggerMiddleware(RequestDelegate next, ILogService logger)
        {
            this._next = next;
            this._logService = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            await this._logService.LogRequest(context, _next);
        }
    }
}
