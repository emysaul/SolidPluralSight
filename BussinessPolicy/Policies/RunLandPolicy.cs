using BussinessPolicy;
using DataConstract.Models;
using DataConstract.Services;
using System;

namespace ArdalisRating.Policies
{
    public class RunLandPolicy : BaseRunPolicy, RunPolicy
    {
        public override decimal CalculateRate(Policy policy)
        {
            return policy.BondAmount * 0.05m;
        }

        public override bool PreValidate(Policy policy)
        {
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                MessagingService.LogMessages("Land policy must specify Bond Amount and Valuation.");
                return false;
            }

            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                Console.WriteLine("Insufficient bond amount.");
                return false;
            }

            return true;
        }
    }
}
