using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            using var activity = ActivitySourceProvider.Source.StartActivity(kind:System.Diagnostics.ActivityKind.Producer,name: "CustomMakeRequestToGoogle");

            try
            {
                var evenTags = new ActivityTagsCollection();

                activity?.AddEvent(new("google'a istek başladı", tags: evenTags));

                activity?.AddTag("request.schema", "https");
                activity?.AddTag("request.metho", "get");


                var result = await httpClient.GetAsync("https://www.google.com");
                var responseContent = await result.Content.ReadAsStringAsync();

                evenTags.Add("google body length", responseContent.Length);
                activity?.AddEvent(new("google'a istek tamamlandı", tags: evenTags));

                var serviceTwo = new ServiceTwo();
                var fileLength = await serviceTwo.WriteToFile("Merhaba Dünya");

                return responseContent.Length;

            }
            catch (Exception ex)
            {
                activity.SetStatus(ActivityStatusCode.Error, ex.Message);
                return -1;
            }

        }
    }
}
