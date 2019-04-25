namespace ArdalisRating.Core.Raters
{
    using ArdalisRating.Core.Interfaces;
    using ArdalisRating.Core.Models;

    public abstract class PolicyRater
    {
        public ILogger Logger { get; set; }

        public PolicyRater(ILogger logger)
        {
            Logger = logger;
        }

        public abstract decimal Rate(Policy policy);
    }
}
