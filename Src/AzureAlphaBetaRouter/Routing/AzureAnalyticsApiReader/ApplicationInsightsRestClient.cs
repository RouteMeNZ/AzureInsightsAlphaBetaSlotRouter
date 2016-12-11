using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RouteMe_Web.Models.Routing.AzureAnalyticsApiReader;

namespace AzureAlphaBetaRouter.Routing.AzureAnalyticsApiReader
{
    public class ApplicationInsightsRestClient
    {
        private readonly string _applicationId;
        private readonly string _apiKey;

        public enum ApplicationInsightsMetricRequestType { metrics, events, query }

        public ApplicationInsightsRestClient(string applicationId, string apiKey)
        {
            _applicationId = applicationId;
            _apiKey = apiKey;
        }

        public async Task<ApplicationInsightsApiResponse> FetchData(ApplicationInsightsMetricRequestType requestType, string timeSpan = "P10D")
        {
            var address = $"https://api.applicationinsights.io/beta/apps/{_applicationId}/{requestType}/requests/failed?timespan={timeSpan}&aggregation=sum";

            ApplicationInsightsApiResponse result;

            using (var client = new HttpClient())
            {
                //As specified here: https://dev.applicationinsights.io/documentation/Authorization/API-key-and-App-ID we require this in the header
                client.DefaultRequestHeaders.Add("X-Api-Key", _apiKey);

                var rawResponse = await client.GetAsync(new Uri(address));
                rawResponse.EnsureSuccessStatusCode(); // Throw in not success

                var stringResponse = await rawResponse.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ApplicationInsightsApiResponse>(stringResponse);
            }

            //3. If not failed
            return result;
        }
    }
}
