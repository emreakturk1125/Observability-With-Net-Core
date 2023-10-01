using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservabilityExamples.ConsoleApp
{
    public static class ActivitySourceProvider
    {
        internal static ActivitySource Source = new ActivitySource(OpenTelemetryConstants.ActivitySourceName); 
    }
}
