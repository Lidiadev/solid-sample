namespace ArdalisRating.Infrastructure.Serializers
{
    using ArdalisRating.Core.Interfaces;
    using ArdalisRating.Core.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class PolicySerializer : IPolicySerializer
    {
        public Policy GetPolicyFromString(string policy)
            => JsonConvert.DeserializeObject<Policy>(policy, new StringEnumConverter());
    }
}
