using EventsItAcademyGe.MVC.Infrastructure.Middlewares;

namespace EventsItAcademyGe.MVC.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseGlobalErrorHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalErrorHandler>();
        }
    }
}
