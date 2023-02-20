using PracticalTask.MiddleWares;

namespace PracticalTask.Extensions
{
    public static class ApplicationBuilderExtension
    {
public static IApplicationBuilder UseErrorLogger(this IApplicationBuilder builder)
{
            builder.UseMiddleware<UnHandledExceptionHandlerMiddleWare>();

            return builder;
}
    }
}
