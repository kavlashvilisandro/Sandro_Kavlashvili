using System;
using Domain.DomainSettings;

namespace Domain.Logger
{
    public sealed class Logger : ILogger
    {
        private static Logger _instance;
        private static object _locker = new object();

        private Logger()
        {

        }

        public static ILogger GetLogger()
        {
            if(_instance == null)
            {
                lock (_locker)
                {
                    if(_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }

        public void LogInformation(string info,string DomainConfigurationPath)
        {
            try
            {
                IDomainConfiguration conf = DomainConfiguration.GetDomainConfiguration(DomainConfigurationPath);
                string InformationPath = conf.GetLoggerConfiguration().InformationPath;
                File.AppendAllText(InformationPath, info + "\n");
            }
            catch (FileNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Check src\\Core\\Domain\\DomainSettings\\DomainSettings.json");
                Console.WriteLine("or check src\\Presentation\\appSettings.json and change");
                Console.WriteLine("File paths for DomainSettings.json,ErrorLogs.txt and InformationLogs.txt");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void LogErrors(string error, string DomainConfigurationPath)
        {
            try
            {
                IDomainConfiguration conf = DomainConfiguration.GetDomainConfiguration(DomainConfigurationPath);
                string ErrorPath = conf.GetLoggerConfiguration().ErrorPath;
                File.AppendAllText(ErrorPath, error + "\n");
            }catch (FileNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Check src\\Core\\Domain\\DomainSettings\\DomainSettings.json");
                Console.WriteLine("or check src\\Presentation\\appSettings.json and change");
                Console.WriteLine("File paths for DomainSettings.json,ErrorLogs.txt and InformationLogs.txt");
                Console.ForegroundColor= ConsoleColor.Gray;
                Console.WriteLine(ex.StackTrace);
            }
        }

        public async Task LogErrorsAsync(string error, string DomainConfigurationPath)
        {
            await Task.Run(() => LogErrors(error, DomainConfigurationPath));
        }

        public async Task LogInformationAsync(string info, string DomainConfigurationPath)
        {
            await Task.Run(() => LogInformation(info, DomainConfigurationPath));
        }
    }
}
