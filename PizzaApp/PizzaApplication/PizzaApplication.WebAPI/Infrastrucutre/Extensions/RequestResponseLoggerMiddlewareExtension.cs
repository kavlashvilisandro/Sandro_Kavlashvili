using PizzaApplication.WebAPI.Infrastrucutre.Middlewares;

namespace PizzaApplication.WebAPI.Infrastrucutre.Extensions
{
    public static class RequestResponseLoggerMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestResponseLogger(this IApplicationBuilder app , WebApplicationBuilder builder)
        {
            return app.UseMiddleware<RequestResponseLoggerMiddleware>(builder);
        }
    }
}
