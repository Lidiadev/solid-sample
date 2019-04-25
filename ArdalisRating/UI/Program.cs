namespace ArdalisRating.UI
{
    using System;
    using ArdalisRating.Core;
    using ArdalisRating.Core.Raters;
    using ArdalisRating.Core.Services;
    using ArdalisRating.Infrastructure.Loggers;
    using ArdalisRating.Infrastructure.PolicySources;
    using ArdalisRating.Infrastructure.Serializers;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ardalis Insurance Rating System Starting...");

            var logger = new ConsoleLogger();

            var engine = new RatingEngine(logger, new PolicyService(new FilePolicySource(logger), new PolicySerializer()), new PolicyRaterFactory(logger));

            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }

            Console.ReadLine();
        }
    }
}
