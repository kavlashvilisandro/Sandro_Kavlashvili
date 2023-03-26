using EventsItAcademyGe.Domain.Exceptions;
using EventsItAcademyGe.MVC.Models;
using EventsItAcademyGe.WebAPI.Infrastructure.Extensions;

namespace EventsItAcademyGe.MVC.Infrastructure.Middlewares
{
    public class GlobalErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public GlobalErrorHandler(RequestDelegate next, IConfiguration config)
        {
            this._next = next;
            this._configuration = config;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch(APIRequestError apiError)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel(apiError);
                unsafe
                {
                    IntPtr pointer = new IntPtr(&errorViewModel);
                    httpContext.Response.Redirect($"/Home/Error/{pointer.ToString()}/{httpContext.TraceIdentifier.Split(":")[0]}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);//Delete
                Console.WriteLine(ex.StackTrace);//Delete
                httpContext.Response.Redirect($"/Home/Index");
            }
        }
    }
}
