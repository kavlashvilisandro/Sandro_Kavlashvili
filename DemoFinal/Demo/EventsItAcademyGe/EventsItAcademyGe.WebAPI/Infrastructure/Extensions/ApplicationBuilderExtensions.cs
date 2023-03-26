using EventsItAcademyGe.WebAPI.Infrastructure.Middlewares;

namespace EventsItAcademyGe.WebAPI.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ResponseLoggerMiddleware>();
            app.UseMiddleware<GlobalErrorHandlerMiddleware>();
            app.UseMiddleware<DataValidationMiddleware>();
            return app.UseMiddleware<RequestLoggerMiddleware>();
        }
    }
}
