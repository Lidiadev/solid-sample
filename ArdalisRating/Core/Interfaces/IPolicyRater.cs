namespace ArdalisRating.Core.Interfaces
{
    using ArdalisRating.Core.Models;

    public interface IPolicyRater
    {
        decimal Rate(Policy policy);
    }
}
