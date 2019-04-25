namespace ArdalisRating.Core
{
    using ArdalisRating.Core.Interfaces;

    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private readonly ILogger _logger;
        private readonly IPolicyService _policyService;
        private readonly IPolicyRaterFactory _policyRaterFactory;
        private IPolicyRater _policyRater;
        
        public decimal Rating { get; set; }

        public RatingEngine(ILogger logger, IPolicyService policyService, IPolicyRaterFactory policyRaterFactory)
        {
            _logger = logger;
            _policyService = policyService;
            _policyRaterFactory = policyRaterFactory;
        }

        public void Rate()
        {
            _logger.Log("Starting rate.");

            var policy = _policyService.GetPolicy();

            _policyRater = _policyRaterFactory.CreatePolicyRater(policy.Type);

            Rating = _policyRater.Rate(policy);

            _logger.Log("Rating completed.");
        }
    }
}
