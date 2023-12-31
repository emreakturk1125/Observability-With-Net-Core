﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservabilityExamples.ConsoleApp
{
    internal class ServiceHelper
    {
        internal async Task Work1()
        {
             using var activity = ActivitySourceProvider.Source.StartActivity();
             var serviceOne = new ServiceOne();

             activity.SetTag("work 1 tag", "work 1 tag value");
            activity.AddEvent(new System.Diagnostics.ActivityEvent("work 1 event"));

             Console.WriteLine($"google response length : {await serviceOne.MakeRequestToGoogle()}");

             Console.WriteLine("Work1 tamamlandı");
        }
    }
}
