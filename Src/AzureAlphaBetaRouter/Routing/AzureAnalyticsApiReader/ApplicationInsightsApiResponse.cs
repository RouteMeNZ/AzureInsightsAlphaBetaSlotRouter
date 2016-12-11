using System.Runtime.Serialization;

namespace RouteMe_Web.Models.Routing.AzureAnalyticsApiReader
{
    public class ApplicationInsightsApiResponse
    {
        public Value value { get; set; }
    }

    public class RequestsFailed
    {
        public int sum { get; set; }
    }

    public class Value
    {
        public string start { get; set; }
        public string end { get; set; }

        [DataMember(Name = "requests/failed")]
        public RequestsFailed FailedRequests { get; set; }
    }
}
