using ToDoAPI.WebAPI.Infrastructure.Middlewares;

namespace ToDoAPI.WebAPI.Infrastructure.Extensions
{
    public static class AddErrorHandler
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalErrorHandlerMiddleware>();
        }
    }
}
