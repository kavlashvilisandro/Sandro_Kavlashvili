using System.Text;

namespace EventsItAcademyGe.WebAPI.Infrastructure.Middlewares
{
    public class ResponseLoggerMiddleware
    {
        private readonly Serilog.ILogger _logger;
        private readonly RequestDelegate _next;

        public ResponseLoggerMiddleware(RequestDelegate next, Serilog.ILogger logger)
        {
            this._logger = logger;
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Stream RealBody = context.Response.Body;

            using(MemoryStream stream = new MemoryStream())
            {
                context.Response.Body = stream;
                await _next.Invoke(context);
                stream.Position = 0;
                using(StreamReader reader = new StreamReader(stream))
                {
                    string responseBody = await reader.ReadToEndAsync();
                    stream.Position = 0;
                    await stream.CopyToAsync(RealBody);
                    context.Response.Body = RealBody;
                    StringBuilder LogData = new StringBuilder();
                    LogData.Append($"[RES({context.Response.Headers["RequestID"]})] => body: ");
                    LogData.Append(responseBody);
                    LogData.Append("\n");
                    _logger.Information(LogData.ToString());
                }
            }
        }
    }
}
