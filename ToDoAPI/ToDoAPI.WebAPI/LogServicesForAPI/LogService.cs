using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;
using System.Diagnostics;
using System.Text.Json;

namespace ToDoAPI.WebAPI.Logs
{
    public class LogService : ILogService
    {
        private readonly Serilog.ILogger _infoLogger;
        private readonly Serilog.ILogger _errorLogger;

        public LogService(IConfiguration config)
        {
            LoggerConfiguration ErrorLoggerConfig = new LoggerConfiguration();
            ErrorLoggerConfig.WriteTo.Console((LogEventLevel)config.GetValue<int>("Serilog:InfoMinLevel"));
            ErrorLoggerConfig.WriteTo.File(config.GetValue<string>("Serilog:ErrorsPath"),
                (LogEventLevel)config.GetValue<int>("Serilog:ErrorMinLevel"));
            this._errorLogger = ErrorLoggerConfig.CreateLogger();


            LoggerConfiguration InfoLoggerConfig = new LoggerConfiguration();
            InfoLoggerConfig.WriteTo.Console((LogEventLevel)config.GetValue<int>("Serilog:InfoMinLevel"));
            InfoLoggerConfig.WriteTo.File(config.GetValue<string>("Serilog:InformationsPath"),
                (LogEventLevel)config.GetValue<int>("Serilog:InfoMinLevel"));

            this._infoLogger = InfoLoggerConfig.CreateLogger();
        }

        public async Task Information(string message)
        {
            _infoLogger.Information(message);
        }

        public async Task LogError(Exception ex)
        {
            StackTrace trace = new StackTrace(ex);
            StackFrame frame = trace.GetFrame(0);
            string PlusData = $"[file: {frame.GetFileName()}],[line: {frame.GetFileLineNumber()}], [method: {frame.GetMethod()}]";
            _errorLogger.Error(ex.Message + " " + PlusData);
        }

        public async Task LogRequest(HttpContext context, RequestDelegate next)
        {
            context.Request.EnableBuffering();

            if (context.Request.Body.CanRead)
            {
                string res = "";
                using(StreamReader reader = new StreamReader(context.Request.Body))
                {
                    res = await reader.ReadToEndAsync();
                    context.Request.Body.Position = 0;
                    _infoLogger.Information(res);
                    await next.Invoke(context);
                }
            }
        }

        public async Task<IActionResult> LogResponse(IActionResult res)
        {
            if(res is ObjectResult)
            {
                _infoLogger.Information(JsonSerializer.Serialize(((ObjectResult)res).Value));
            }
            return res;
        }
    }
}
