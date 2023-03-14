using Microsoft.AspNetCore.Mvc;
using ToDoAPI.WebAPI.Logs;

namespace ToDoAPI.WebAPI.Infrastructure.Models
{
    public static class Res
    {
        public static async Task<IActionResult> Response(this IActionResult res, IServiceProvider provider)
        {
            ILogService logger = provider.GetService<ILogService>();
            return await logger.LogResponse(res);
        }
    }
}
