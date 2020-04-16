using BussinessPolicy;
using DataConstract.Models;
using DataConstract.Services;
using System;

namespace ArdalisRating.Policies
{
    public class RunAutoPolicy : BaseRunPolicy, RunPolicy
    {
        public override decimal CalculateRate(Policy policy)
        {
            decimal Rating = -1;

            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                    Rating = 1000m;

                Rating = 900m;
            }

            return Rating;
        }

        public override bool PreValidate(Policy policy)
        {
            if (String.IsNullOrEmpty(policy.Make))
            {
                MessagingService.LogMessages("Auto policy must specify Make");
                return false;
            }

            return true;
        }
    }
}
