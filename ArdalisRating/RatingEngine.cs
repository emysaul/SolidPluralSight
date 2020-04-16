using DataConstract.Models;
using DataConstract.Providers;
using DataConstract.Services;
using LogImplementation;
using PersistenceFileImplementation;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private readonly PolicyProvider PolicyProvider;
        private readonly MessagingService MessagingService;

        private readonly PolicyFactory policyFactory = new PolicyFactory();
        public RatingEngine()
        {
            PolicyProvider = new FilePolicyProvider();
            MessagingService = new ConsoleMessagingServiceImplementation();

        }

        public decimal Rating { get; set; }
        public void Rate()
        {
            MessagingService.LogMessages("Starting rate.", "Loading policy.");

            Policy policy = PolicyProvider.GetPolicy("policy.json");

            Rating = policyFactory.RunPolicy(policy);

            MessagingService.LogMessages("Rating completed.");
        }
    }
}
