using System.Text;

namespace EventsItAcademyGe.WebAPI.Infrastructure.Middlewares
{
    public class RequestLoggerMiddleware
    {
        private readonly Serilog.ILogger _logger;
        private readonly RequestDelegate _next;

        public RequestLoggerMiddleware(RequestDelegate next, Serilog.ILogger logger)
        {
            this._logger = logger;
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableBuffering();

            using (StreamReader reader = new StreamReader(context.Request.Body))
            {
                string data = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;
                data = data.Replace("\n", "");
                string uniqueIdentifier = Guid.NewGuid().ToString();
                StringBuilder body = new StringBuilder();
                body.Append($"[REQ({uniqueIdentifier})] => body: ");
                body.Append(data);
                body.Append(" | PATH: ");
                body.Append(context.Request.Path.ToString());
                body.Append("\n");
                _logger.Information(body.ToString());
                context.Response.Headers.Add("RequestID",uniqueIdentifier);
                await _next.Invoke(context);
            }
        }
    }
}
