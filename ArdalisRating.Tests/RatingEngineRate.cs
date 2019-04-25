namespace ArdalisRating.Tests
{
    using System;
    using ArdalisRating.Core;
    using ArdalisRating.Core.Interfaces;
    using ArdalisRating.Core.Models;
    using ArdalisRating.Core.Raters;
    using FluentAssertions;
    using Moq;
    using Xunit;

    public class RatingEngineRate
    {
        private readonly Mock<ILogger> _logger;
        private readonly Mock<IPolicyService> _policyService;
        private readonly Mock<IPolicyRaterFactory> _policyRaterFactory;
        private readonly RatingEngine _subject;

        public RatingEngineRate()
        {
            _logger = new Mock<ILogger>();
            _policyService = new Mock<IPolicyService>();
            _policyRaterFactory = new Mock<IPolicyRaterFactory>();
            _subject = new RatingEngine(_logger.Object, _policyService.Object, _policyRaterFactory.Object);
        }

        [Theory]
        [InlineData(200000, 10000)]
        [InlineData(260000, 0)]
        public void Rate_LandPolicy_ReturnsCorrectRating(decimal valuation, decimal expectedRate)
        {
            _policyService.Setup(x => x.GetPolicy())
                .Returns(new Policy
                {
                    Type = PolicyType.Land,
                    BondAmount = 200000,
                    Valuation = valuation
                });
            _policyRaterFactory.Setup(x => x.CreatePolicyRater(PolicyType.Land))
                .Returns(new LandPolicyRater(_logger.Object));
           
            _subject.Rate();

            _subject.Rating.Should().Be(expectedRate);
        }

        [Theory]
        [InlineData(400, 1000)]
        [InlineData(260000, 900)]
        public void Rate_AutoPolicy_ReturnsCorrectRating(decimal deductible, decimal expectedRate)
        {
            _policyService.Setup(x => x.GetPolicy())
                .Returns(new Policy
                {
                    Type = PolicyType.Auto,
                    Deductible = deductible,    
                    Make = "BMW"
                });
            _policyRaterFactory.Setup(x => x.CreatePolicyRater(PolicyType.Auto))
                .Returns(new AutoPolicyRater(_logger.Object));

            _subject.Rate();

            _subject.Rating.Should().Be(expectedRate);
        }

        [Theory]
        [InlineData("1970-05-10", 240000)]
        [InlineData("1918-05-10", 0)]
        public void Rate_LifePolicy_ReturnsCorrectRating(string dateOfBirth, decimal expectedRate)
        {
            _policyService.Setup(x => x.GetPolicy())
                .Returns(new Policy
                {
                    Type = PolicyType.Life,
                    Amount = 1000000,
                    DateOfBirth = DateTime.Parse(dateOfBirth)
                });
            _policyRaterFactory.Setup(x => x.CreatePolicyRater(PolicyType.Life))
                .Returns(new LifeInsurancePolicyRater(_logger.Object));

            _subject.Rate();

            _subject.Rating.Should().Be(expectedRate);
        }
    }
}
