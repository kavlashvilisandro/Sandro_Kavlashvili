using Microsoft.AspNetCore.Mvc;

namespace ToDoAPI.WebAPI.Logs
{
    public interface ILogService
    {
        public Task LogError(Exception ex);
        public Task Information(string message);

        public Task LogRequest(HttpContext context, RequestDelegate next);

        public Task<IActionResult> LogResponse(IActionResult res);
    }
}
