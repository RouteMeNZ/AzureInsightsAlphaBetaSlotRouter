namespace AzureAlphaBetaRouter.Routing.Models
{
    public enum RoutingStatus
    {
        Success = 0,
        RouterIssuesTestFailed = 1,
        JavascriptErrorsTestFailed = 2,
        ServerSideErrorsTestFailed = 4,
        LatencyRegressionTestFailed = 8,
        CustomerConversionRegressionTestFailed = 16,
        CustomerBounceRateTestFailed = 32,
        CustomerAverageTimeSpentOnPageTestFailed = 64
    }
}
