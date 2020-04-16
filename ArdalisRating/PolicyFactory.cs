
using BussinessPolicy;
using DataConstract.Enums;
using DataConstract.Models;
using DataConstract.Services;
using LogImplementation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArdalisRating
{
    public class PolicyFactory
    {
        private readonly MessagingService MessagingService;

        public PolicyFactory()
        {
            MessagingService = new ConsoleMessagingServiceImplementation();
        }

        public decimal RunPolicy(Policy policy)
        {
            RunPolicy runPolicy = GetRunPolicy(policy.Type);

            MessagingService.LogMessages($"Rating {Enum.GetName(typeof(PolicyType), policy.Type)} policy...", "Validating policy.");

            if (runPolicy != null)
                return runPolicy.Start(policy); ;

            MessagingService.LogMessages("Unknown policy type");
            return 0;
        }

        private RunPolicy GetRunPolicy(PolicyType policyType)
        {
            var policyTypeName = Enum.GetName(typeof(PolicyType), policyType);

            return GetImplementationFromInterface<RunPolicy>($"Run{policyTypeName}Policy");
        }

        public T GetImplementationFromInterface<T>(string implementationName) where T : class
        {
            IEnumerable<Type> runPolicysTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(T).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var policy in runPolicysTypes)
            {
                if (policy.Name == implementationName)
                {
                    return (T)Activator.CreateInstance(policy);
                }
            }

            return null;
        }
    }
}