using System;
using System.Threading.Tasks;
using AzureAlphaBetaRouter.Routing.AzureAnalyticsApiReader;
using AzureAlphaBetaRouter.Strategies.Common;

namespace AzureAlphaBetaRouter.Strategies
{
    /// <summary>
    /// Details of the API used in this class are here: https://msdn.microsoft.com/en-us/library/azure/dn931965.aspx
    /// </summary>
    public class LatencyVerificationStrategy : DeploymentVerificationStrategy
    {
        public LatencyVerificationStrategy()
        {
            TakesInstantEffect = false;
        }

        public override async Task<bool> VerifyDeploymentResult(ApplicationInsightsRestClient restClient)
        {
            var webTestName = "Production up-time test";
            var apiVersion = "1.1";
            var resourceGroupName = "RouteMe";
            await restClient.FetchLatencyVerification(resourceGroupName, webTestName, apiVersion);

            //This is started but not finished. Need to integrate to finish the rest.
            throw new NotImplementedException();
        }

        public override string ReasonFailed { get; protected set; }
    }
}
