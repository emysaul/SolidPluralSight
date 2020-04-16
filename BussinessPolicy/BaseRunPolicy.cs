using DataConstract.Models;
using DataConstract.Services;
using LogImplementation;

namespace BussinessPolicy
{
    public abstract class BaseRunPolicy
    {
        protected readonly MessagingService MessagingService;

        public BaseRunPolicy()
        {
            MessagingService = new ConsoleMessagingServiceImplementation();
        }

        public abstract bool PreValidate(Policy policy);
        public abstract decimal CalculateRate(Policy policy);

        public decimal Start(Policy policy) => PreValidate(policy) ? CalculateRate(policy) : 0;
    }
}
