using AzureAlphaBetaRouter.Routing.AzureAnalyticsApiReader;

namespace Tests.Mocks
{
    public class ApplicationInsightsRestClientMock : ApplicationInsightsRestClient
    {
        public ApplicationInsightsRestClientMock() : base(string.Empty, string.Empty)
        {

        }
    }
}
