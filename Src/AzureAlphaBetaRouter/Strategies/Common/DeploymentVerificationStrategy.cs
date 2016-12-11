using System.Threading.Tasks;
using AzureAlphaBetaRouter.Routing.AzureAnalyticsApiReader;

namespace AzureAlphaBetaRouter.Strategies.Common
{
    public abstract class DeploymentVerificationStrategy
    {
        //Abstract
        public abstract Task<bool> VerifyDeploymentResult(ApplicationInsightsRestClient restClient);

        public abstract string ReasonFailed { get; protected set; }

        //Implementation
        public bool VerificationPassed => string.IsNullOrWhiteSpace(ReasonFailed);
        public bool TakesInstantEffect { get; set; }
    }
}
