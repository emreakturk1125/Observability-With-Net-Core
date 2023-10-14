using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ObservabilityExamples.ConsoleApp
{
    public class Program
    {
       static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

           using var traceProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(OpenTelemetryConstants.ActivitySourceName)
                .ConfigureResource(conf =>
            {
                conf.AddService(OpenTelemetryConstants.ServiceName, serviceVersion: OpenTelemetryConstants.ServiceVerison)
                .AddAttributes(new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("host.machineName",Environment.MachineName),
                    new KeyValuePair<string, object>("host.environment","dev")
                });
            }).AddConsoleExporter().AddOtlpExporter().Build();


            var serviceHelper = new ServiceHelper();
            await serviceHelper.Work1();

        }
    }
}
