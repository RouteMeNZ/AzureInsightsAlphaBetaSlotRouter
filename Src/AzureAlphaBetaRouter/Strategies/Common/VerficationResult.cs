using System;

namespace AzureAlphaBetaRouter.Strategies.Common
{
    public class VerificationResult<T> where T: DeploymentVerificationStrategy
    {
        public VerificationResult(string reasonFailed)
        {
            ReasonFailed = reasonFailed;
        }

        public bool VerificationPassed => string.IsNullOrWhiteSpace(ReasonFailed);

        public string ReasonFailed { get; }

        public Type VerificationType => typeof(T);
    }
}
