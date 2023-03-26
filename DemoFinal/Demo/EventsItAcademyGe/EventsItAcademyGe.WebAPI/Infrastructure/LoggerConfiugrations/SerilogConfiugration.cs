using Serilog;
using Serilog.Events;

namespace EventsItAcademyGe.WebAPI.Infrastructure.LoggerConfiugrations
{
    public static class SerilogConfiugration
    {
        public static Serilog.ILogger ConfigureSerilog(IConfiguration Config)
        {
            LoggerConfiguration configuration = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Logger((LoggerConfiguration config) =>
                {
                    config.Filter.ByIncludingOnly((LogEvent e) => e.Level == LogEventLevel.Information)
                    .WriteTo.File
                    (
                        path: Directory.GetCurrentDirectory() + Config.GetValue<string>("LoggerConfiguration:RequestResponsesPath"),
                        restrictedToMinimumLevel: LogEventLevel.Information,
                        outputTemplate: "===[{Timestamp:yyyy:MM:dd HH:mm:ss.fff zzz} {Level:u3}] --> {Message:lj}"
                    );
                }).WriteTo.Logger((LoggerConfiguration config) =>
                {
                    config.WriteTo.File
                    (
                        path: Directory.GetCurrentDirectory() + Config.GetValue<string>("LoggerConfiguration:ErrorsPath"),
                        restrictedToMinimumLevel: LogEventLevel.Error,
                        outputTemplate: "===[{Timestamp:yyyy:MM:dd HH:mm:ss.fff zzz} {Level:u3}]=== \n[\n       {Message:lj}\n]\n"
                    );
                });
            return configuration.CreateLogger();
        }
    }
}
