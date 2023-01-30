using System;
using System.Text.Json;

namespace Domain.DomainSettings
{
    public  class DomainConfiguration : IDomainConfiguration
    {
        public LoggerConfiguration Logger { get; set; }
        public DomainConfiguration()
        {

        }

        public LoggerConfiguration GetLoggerConfiguration()
        {
            return this.Logger;
        }

        public static IDomainConfiguration GetDomainConfiguration(string DomainSettingsPath)
        {
            string ConfigureFile = File.ReadAllText(DomainSettingsPath);
            return JsonSerializer.Deserialize<DomainConfiguration>(ConfigureFile);
        }

    }
}
