﻿using System;
using System.Collections.Generic;
using AzureAlphaBetaRouter.Routing;
using AzureAlphaBetaRouter.Routing.Models;
using AzureAlphaBetaRouter.Strategies;
using AzureAlphaBetaRouter.Strategies.Common;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Tests.Mocks;

namespace Tests.tests
{
    [Binding]
    public class AzureWebSlotTrafficRoutingSteps
    {
        private const string RoutingStatusKey = "RoutingStatusKey";
        private const string RoutingResultKey = "RoutingResultKey";
        private const string RoutingDefaultValueKey = "RoutingDefaultValueKey";
        private const string RoutingDefaultIncrementKey = "RoutingDefaultIncrementKey";

        [Given(@"I have a build with (.*)")]
        public void GivenIHaveABuildWith(string problem)
        {
            List<DeploymentVerificationStrategy> problemType;

            //Consider a design pattern here to define what a router issue is and use a list to capture those issues and their details
            switch (problem)
            {
                case "no problem":
                    problemType = new List<DeploymentVerificationStrategy>();
                    break;
                case "Router issues":
                    problemType = new List<DeploymentVerificationStrategy> { MocksFactory.GetRouterVerificationStrategy() };
                    break;
                case "Javascript errors":
                case "Server side errors":
                    problemType = new List<DeploymentVerificationStrategy> { MocksFactory.GetWebsiteExceptionsStrategy() };
                    break;
                case "Latency regression":
                    problemType = new List<DeploymentVerificationStrategy> { MocksFactory.GetLatencyStrategy() };
                    break;
                case "Customer conversion regression":
                    problemType = new List<DeploymentVerificationStrategy> { MocksFactory.CustomerConversionRegressionStrategy() };
                    break;
                case "Customer bounce rate":
                    problemType = new List<DeploymentVerificationStrategy> { MocksFactory.CustomerBounceRateStrategy() };
                    break;
                case "Customer average time spent on page":
                    problemType = new List<DeploymentVerificationStrategy> { MocksFactory.CustomerAverageTimeOnPageStrategy()  };
                    break;
                case "Server side errors & Latency regression":
                    problemType = new List<DeploymentVerificationStrategy> { MocksFactory.GetWebsiteExceptionsStrategy(),
                                                                             MocksFactory.GetLatencyStrategy()};
                    break;
                case "Customer bounce rate & Customer average time spent on page":
                    problemType = new List<DeploymentVerificationStrategy> { MocksFactory.CustomerBounceRateStrategy(),
                                                                             MocksFactory.CustomerAverageTimeOnPageStrategy() };
                    break;
                case "All issue types":
                    problemType = new List<DeploymentVerificationStrategy> { MocksFactory.GetRouterVerificationStrategy(),
                                                                             MocksFactory.GetWebsiteExceptionsStrategy(),
                                                                             MocksFactory.GetLatencyStrategy(),
                                                                             MocksFactory.CustomerConversionRegressionStrategy(),
                                                                             MocksFactory.CustomerBounceRateStrategy(),
                                                                             MocksFactory.CustomerAverageTimeOnPageStrategy()};
                    break;
                default:
                    throw new NotSupportedException("Use a supported case");
            }

            ScenarioContext.Current.Add(RoutingStatusKey, problemType);
        }

        [Given("I have a default of 10% with a 5% increment")]
        public void GivenIHaveADefaultOfWithAnIncrement()
        {
            ScenarioContext.Current.Add(RoutingDefaultValueKey, 10);
            ScenarioContext.Current.Add(RoutingDefaultIncrementKey, 5);
        }

        [When(@"I deploy a new staging build")]
        public void WhenIDeployANewStagingBuild()
        {
            var mockRestClient = new ApplicationInsightsRestClientMock();
            var startingBalancePercentage = ScenarioContext.Current.Get<int>(RoutingDefaultValueKey);
            var strategies = ScenarioContext.Current.Get<List<DeploymentVerificationStrategy>>(RoutingStatusKey);
            var stepUpPercentage = ScenarioContext.Current.Get<int>(RoutingDefaultIncrementKey);

            ScenarioContext.Current.Add(RoutingResultKey,AzureSlotRouter.ChangeDirectionResult(mockRestClient, startingBalancePercentage, stepUpPercentage, strategies));
        }

        [Then(@"I expect to see the the percentage of traffic go down to (.*)")]
        public void ThenIExpectToSeeThePercentageOfTrafficGoDownToZeroPercent(string percentageExpected)
        {
            var percentageNormalizedString = percentageExpected.TrimEnd('%');
            var percentageNumberExpected = int.Parse(percentageNormalizedString);
            var percentageNumberActual = ScenarioContext.Current.Get<AzureWebsiteRoutingEntites.ChangeDirectionResult>(RoutingResultKey).RoutingPercentage;

            Assert.AreEqual(percentageNumberExpected, percentageNumberActual);
        }

        [Then(@"I expect to see the percentage of traffic go up to 15%")]
        public void ThenIExpectToSeeThePercentageOfTrafficGoUpToFiftyPercentage()
        {
            var percentageNumberActual = ScenarioContext.Current.Get<AzureWebsiteRoutingEntites.ChangeDirectionResult>(RoutingResultKey).RoutingPercentage;

            Assert.AreEqual(15, percentageNumberActual);
        }
    }
}
