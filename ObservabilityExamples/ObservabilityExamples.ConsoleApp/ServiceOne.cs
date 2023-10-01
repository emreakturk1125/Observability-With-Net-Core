using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ObservabilityExamples.ConsoleApp
{
    internal class ServiceOne
    {
        static HttpClient httpClient = new HttpClient();
       internal async Task<int> MakeRequestToGoogle()
        {
            using var activity = ActivitySourceProvider.Source.StartActivity();

            var result = await httpClient.GetAsync("https://www.google.com");

            var responseContent =  await result.Content.ReadAsStringAsync();

            return responseContent.Length;
        }
    }
}
