using ToDoAPI.WebAPI.Infrastructure.Middlewares;

namespace ToDoAPI.WebAPI.Infrastructure.Extensions
{
    public static class AddAuthorization
    {
        public static IApplicationBuilder AddJWTAuthorization(this IApplicationBuilder app, IConfiguration config, string audience)
        {
            return app.UseMiddleware<JWTAuthenticationMiddleware>(config, audience);
        }
    }
}
