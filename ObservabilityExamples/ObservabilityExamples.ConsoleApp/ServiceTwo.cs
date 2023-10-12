using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ObservabilityExamples.ConsoleApp
{
    internal class ServiceTwo
    {
        static HttpClient httpClient = new HttpClient();
        internal async Task<int> WriteToFile(string text)
        {
            using var activity = ActivitySourceProvider.Source.StartActivity();  // 2 ya da daha fazla activity olacaksa using ifadesi parente< olarak tanımlanmalıdır. Ama tek activity de abu şekilde yeterlidir
              
            await File.WriteAllTextAsync("myFile.txt", text);
            return (await File.ReadAllTextAsync("myFile.txt")).Length;
             
        }
    }
}
