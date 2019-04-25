namespace ArdalisRating.Core.Services
{
    using ArdalisRating.Core.Interfaces;
    using ArdalisRating.Core.Models;

    public class PolicyService : IPolicyService
    {
        private readonly IPolicySource _policySource;
        private readonly IPolicySerializer _policySerializer;

        public PolicyService(IPolicySource policySource, IPolicySerializer policySerializer)
        {
            _policySource = policySource;
            _policySerializer = policySerializer;
        }

        public Policy GetPolicy()
            => _policySerializer.GetPolicyFromString(_policySource.GetPolicyFromSource());
    }
}
