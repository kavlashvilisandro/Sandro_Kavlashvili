using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainSettings
{
    public interface IDomainConfiguration
    {
        LoggerConfiguration GetLoggerConfiguration();
    }
}
