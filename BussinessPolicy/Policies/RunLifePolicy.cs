using BussinessPolicy;
using DataConstract.Models;
using DataConstract.Services;
using System;

namespace ArdalisRating.Policies
{
    public class RunLifePolicy : BaseRunPolicy, RunPolicy
    {
        public override bool PreValidate(Policy policy)
        {
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                MessagingService.LogMessages("Life policy must include Date of Birth.");
                return false;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                MessagingService.LogMessages("Centenarians are not eligible for coverage.");
                return false;
            }
            if (policy.Amount == 0)
            {
                MessagingService.LogMessages("Life policy must include an Amount.");
                return false;
            }

            return true;
        }

        public override decimal CalculateRate(Policy policy)
        {
            int age = DateTime.Today.Year - policy.DateOfBirth.Year;
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = policy.Amount * age / 200;
            if (policy.IsSmoker)
                return baseRate * 2;

            return baseRate;
        }
    }
}
