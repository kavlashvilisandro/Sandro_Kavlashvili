using System;


namespace Domain.Logger
{
    public interface ILogger
    {
        public void LogInformation(string info, string DomainConfigurationPath);
        public void LogErrors(string error, string DomainConfigurationPath);

        public Task LogErrorsAsync(string error, string DomainConfigurationPath);

        public Task LogInformationAsync(string info, string DomainConfigurationPath);
    }
}
