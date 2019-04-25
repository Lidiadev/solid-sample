namespace ArdalisRating.Core.Interfaces
{
    using ArdalisRating.Core.Models;

    public interface IPolicySerializer
    {
        Policy GetPolicyFromString(string policy);
    }
}
