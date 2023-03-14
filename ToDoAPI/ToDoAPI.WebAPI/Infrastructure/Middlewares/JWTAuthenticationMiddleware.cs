using Microsoft.Extensions.Primitives;
using ToDoAPI.WebAPI.Infrastructure.Auth;

namespace ToDoAPI.WebAPI.Infrastructure.Middlewares
{
    public class JWTAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly string _audience;

        public JWTAuthenticationMiddleware(RequestDelegate next, IConfiguration config,string audience)
        {
            this._next = next;
            this._configuration = config;
            this._audience = audience;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Request.Headers.TryGetValue("JWTToken", out StringValues Res);
            if (Res.Equals(""))
            {
                throw new Exception("JWT token is in incorrect format");
            }
            else
            {
                if (JWT.ValidateToken(Res.ToString(),_audience,_configuration))
                {
                    await this._next.Invoke(context);
                }
            }
        }

    }
}
