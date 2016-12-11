using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureAlphaBetaRouter.Strategies;
using AzureAlphaBetaRouter.Strategies.Common;
using Moq;

namespace Tests.Mocks
{
    public static class MocksFactory
    {
        public static LatencyVerificationStrategy GetLatencyStrategy()
        {
            var latencyProblemVerification = new Mock<LatencyVerificationStrategy>();
            latencyProblemVerification.Setup(x => x.VerifyDeploymentResult(null)).ReturnsAsync(false);
            latencyProblemVerification.Setup(x => x.VerificationPassed).Returns(false);
            return latencyProblemVerification.Object;
        }

        public static WebsiteExceptionsStrategy GetWebsiteExceptionsStrategy()
        {
            var websiteExceptionVerfication = new Mock<WebsiteExceptionsStrategy>();
            websiteExceptionVerfication.Setup(x => x.VerifyDeploymentResult(null)).ReturnsAsync(false);
            websiteExceptionVerfication.Setup(x => x.VerificationPassed).Returns(false);
            websiteExceptionVerfication.Setup(x => x.TakesInstantEffect).Returns(true);  //Not sure why this is needed. it seems to default to false. Perhaps because its set in constructor?
            return websiteExceptionVerfication.Object;
        }

        public static RouterVerificationStrategy GetRouterVerificationStrategy()
        {
            var routingProblemFound = new Mock<RouterVerificationStrategy>();
            routingProblemFound.Setup(x => x.VerifyDeploymentResult(null)).ReturnsAsync(false);
            routingProblemFound.Setup(x => x.VerificationPassed).Returns(false);
            return routingProblemFound.Object;
        }

        public static CustomerConversionRegressionStrategy CustomerConversionRegressionStrategy()
        {
            var customerConversionRegressionStrategy = new Mock<CustomerConversionRegressionStrategy>();
            customerConversionRegressionStrategy.Setup(x => x.VerifyDeploymentResult(null)).ReturnsAsync(false);
            customerConversionRegressionStrategy.Setup(x => x.VerificationPassed).Returns(false);
            return customerConversionRegressionStrategy.Object;
        }

        public static CustomerBounceRateStrategy CustomerBounceRateStrategy()
        {
            var customerBounceRateStrategy = new Mock<CustomerBounceRateStrategy>();
            customerBounceRateStrategy.Setup(x => x.VerifyDeploymentResult(null)).ReturnsAsync(false);
            customerBounceRateStrategy.Setup(x => x.VerificationPassed).Returns(false);
            return customerBounceRateStrategy.Object;
        }

        public static CustomerAverageTimeOnPageStrategy CustomerAverageTimeOnPageStrategy()
        {
            var customerAverageTimeOnPageStrategy = new Mock<CustomerAverageTimeOnPageStrategy>();
            customerAverageTimeOnPageStrategy.Setup(x => x.VerifyDeploymentResult(null)).ReturnsAsync(false);
            customerAverageTimeOnPageStrategy.Setup(x => x.VerificationPassed).Returns(false);
            return customerAverageTimeOnPageStrategy.Object;
        }
    }
}
