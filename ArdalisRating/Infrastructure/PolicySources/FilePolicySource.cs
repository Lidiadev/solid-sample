namespace ArdalisRating.Infrastructure.PolicySources
{
    using System.IO;
    using ArdalisRating.Core.Interfaces;

    public class FilePolicySource : IPolicySource
    {
        private readonly ILogger _logger;

        public FilePolicySource(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///  Open file policy.json
        /// </summary>
        public string GetPolicyFromSource()
        {
            _logger.Log("Loading policy.");

            return File.ReadAllText("policy.json");
        }
    }
}
