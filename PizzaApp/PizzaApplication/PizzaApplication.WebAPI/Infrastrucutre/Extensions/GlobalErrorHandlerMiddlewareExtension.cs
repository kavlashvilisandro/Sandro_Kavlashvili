using PizzaApplication.WebAPI.Infrastrucutre.Middlewares;

namespace PizzaApplication.WebAPI.Infrastrucutre.Extensions
{
    public static class GlobalErrorHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseGlobalErrorHandler(this IApplicationBuilder app , WebApplicationBuilder builder)
        {
            return app.UseMiddleware<GlobalErrorHandlerMiddleware>(builder);
        }
    }
}
