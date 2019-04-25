namespace ArdalisRating.Core.Interfaces
{
    using ArdalisRating.Core.Models;

    public interface IPolicyRaterFactory
    {
        IPolicyRater CreatePolicyRater(PolicyType policyType);
    }
}
