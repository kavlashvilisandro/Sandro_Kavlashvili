using ToDoAPI.WebAPI.Infrastructure.Middlewares;


namespace ToDoAPI.WebAPI.Infrastructure.Extensions
{
    public static class AddRequestLogger
    {
        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestLoggerMiddleware>();
        }
    }
}
