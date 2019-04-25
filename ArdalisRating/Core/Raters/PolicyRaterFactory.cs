namespace ArdalisRating.Core.Raters
{
    using ArdalisRating.Core.Interfaces;
    using ArdalisRating.Core.Models;

    public class PolicyRaterFactory : IPolicyRaterFactory
    {
        private readonly ILogger _logger;

        public PolicyRaterFactory(ILogger logger)
        {
            _logger = logger;
        }

        public IPolicyRater CreatePolicyRater(PolicyType policyType)
        {
            switch (policyType)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(_logger);
                case PolicyType.Land:
                    return new LandPolicyRater(_logger);
                case PolicyType.Life:
                    return new LifeInsurancePolicyRater(_logger);
                default:
                    return new UnkownPolicyRater(_logger);
            }
        }
    }
}
