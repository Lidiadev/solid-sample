namespace ArdalisRating.Core.Raters
{
    using ArdalisRating.Core.Interfaces;
    using ArdalisRating.Core.Models;

    public class UnkownPolicyRater : IPolicyRater
    {
        private readonly ILogger _logger;

        public UnkownPolicyRater(ILogger logger)
        {
            _logger = logger;
        }

        public decimal Rate(Policy policy)
        {
            _logger.Log("Unknown policy type");

            return 0m;
        }
    }
}
