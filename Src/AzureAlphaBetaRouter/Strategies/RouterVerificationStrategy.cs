using System;
using System.Threading.Tasks;
using AzureAlphaBetaRouter.Routing.AzureAnalyticsApiReader;
using AzureAlphaBetaRouter.Strategies.Common;

namespace AzureAlphaBetaRouter.Strategies
{
    public class RouterVerificationStrategy : DeploymentVerificationStrategy
    {
        public override Task<bool> VerifyDeploymentResult(ApplicationInsightsRestClient restClient)
        {
            throw new NotImplementedException();
        }

        public override string ReasonFailed { get; protected set; }
    }
}
