using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservabilityExamples.ConsoleApp
{
    internal class OpenTelemetryConstants
    {
        internal const string ServiceName = "ConsoleApp"; // CompanyName.AppName.ComponentName
        internal const string ServiceVerison = "1.0.0";
        internal const string ActivitySourceName = "ActivitySource.ConsoleApp";
    }
}
