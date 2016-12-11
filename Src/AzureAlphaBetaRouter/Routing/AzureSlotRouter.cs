using System;
using System.Collections.Generic;
using System.Linq;
using AzureAlphaBetaRouter.Routing.AzureAnalyticsApiReader;
using AzureAlphaBetaRouter.Routing.Models;
using AzureAlphaBetaRouter.Strategies.Common;

namespace AzureAlphaBetaRouter.Routing
{
    public class AzureSlotRouter
    {
        public static AzureWebsiteRoutingEntites.ChangeDirectionResult ChangeDirectionResult(ApplicationInsightsRestClient restClient, long currentBalancePercentage, List<DeploymentVerificationStrategy> strategies)
        {
            foreach (var deploymentVerificationStrategy in strategies)
            {
                deploymentVerificationStrategy.VerifyDeploymentResult(restClient);
            }

            var failedResults = strategies.Where(strategy => !strategy.VerificationPassed);

            var deploymentVerificationStrategies = failedResults as IList<DeploymentVerificationStrategy> ??
                                                   failedResults.ToList();

            if (!deploymentVerificationStrategies.Any())
            {
                return new AzureWebsiteRoutingEntites.ChangeDirectionResult
                {
                    Step = Math.Min((int)currentBalancePercentage + 10, 100)
                };
            }

            //Have we failed catestrophically?
            if (deploymentVerificationStrategies.Any(result => result.TakesInstantEffect))
            {
                // Use either Step or RoutingPercentage. If both returned RoutingPercentage takes precedence
                return new AzureWebsiteRoutingEntites.ChangeDirectionResult
                {
                    RoutingPercentage = 0
                };
            }

            //We have failed but we haven't failed catestrophically yet.
            // Use either Step or RoutingPercentage. If both returned RoutingPercentage takes precedence
            return new AzureWebsiteRoutingEntites.ChangeDirectionResult
            {
                //Take us down towards zero but not lower than zero as it makes no sense to Azure.
                Step = Math.Max((int)currentBalancePercentage - 10, 0)
            };

            // Use either Step or RoutingPercentage. If both returned RoutingPercentage takes precedence
        }
    }
}
