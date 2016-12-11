using System.Threading.Tasks;
using AzureAlphaBetaRouter.Routing.AzureAnalyticsApiReader;
using AzureAlphaBetaRouter.Strategies.Common;

namespace AzureAlphaBetaRouter.Strategies
{
    public class WebsiteExceptionsStrategy : DeploymentVerificationStrategy
    {
        public WebsiteExceptionsStrategy()
        {
            //If we have any technical issues like this it should take instant affect.
            TakesInstantEffect = true;
        }

        public override async Task<bool> VerifyDeploymentResult(ApplicationInsightsRestClient restClient)
        {
            var result = await restClient.FetchWebExceptionsResult(ApplicationInsightsRestClient.ApplicationInsightsMetricRequestType.metrics, "P5D");

            var numberOfExceptionsFoundForWebsite = result?.value?.FailedRequests?.sum;

            if (numberOfExceptionsFoundForWebsite == 0)
                return true;

            ReasonFailed = $"There were {numberOfExceptionsFoundForWebsite} number of website exceptions introduced";
            return false;
        }

        public override string ReasonFailed { get; protected set; }
    }
}
