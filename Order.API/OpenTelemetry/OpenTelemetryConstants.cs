using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.API.OpenTelemetry
{
    public class OpenTelemetryConstants
    {
        public static string ServiceName { get; set; } = null!;
        public static string ServiceVersion { get; set; } = null!;
        public static string ActivitySourceName { get; set; } = null!;

    }
}
