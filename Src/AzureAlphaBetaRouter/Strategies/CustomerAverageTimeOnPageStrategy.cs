using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureAlphaBetaRouter.Routing.AzureAnalyticsApiReader;
using AzureAlphaBetaRouter.Strategies.Common;

namespace AzureAlphaBetaRouter.Strategies
{
    public class CustomerAverageTimeOnPageStrategy : DeploymentVerificationStrategy
    {
        public CustomerAverageTimeOnPageStrategy()
        {
            TakesInstantEffect = false;
        }

        public override async Task<bool> VerifyDeploymentResult(ApplicationInsightsRestClient restClient)
        {
            var webTestName = "Production up-time test";
            var apiVersion = "1.1";
            var resourceGroupName = "RouteMe";
            await restClient.FetchCustomerAverageTimeOnPageResult(resourceGroupName, webTestName, apiVersion);

            //This is started but not finished. Need to integrate to finish the rest.
            throw new NotImplementedException();
        }

        public override string ReasonFailed { get; protected set; }
    }
}
