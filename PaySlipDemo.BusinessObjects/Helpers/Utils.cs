using System;

namespace PaySlipDemo.BusinessObjects.Helpers
{
    public static class Utils
    {
        public static decimal CalculateGrossIncome(this decimal annualSalary)
        {
            return (annualSalary / 12).RoundOffDoller();
        }

        public static decimal RoundOffDoller(this decimal amount)
        {
            return Math.Round(amount, MidpointRounding.AwayFromZero);
        }

        public static decimal GetTaxSlabAmount(this decimal amount)
        {           
            if (amount.IsWithin(0, 18200))
            {
                return 0.00m;
            }
            else if (amount.IsWithin(18201, 37000))
            {
                return (amount.CalculateTaxPerDoller(18200, .19m) / 12).RoundOffDoller();
            }
            else if (amount.IsWithin(37001, 87000))
            {
                return ((3572 + amount.CalculateTaxPerDoller(37000, .32m)) / 12).RoundOffDoller();
            }
            else if (amount.IsWithin(87001, 180000))
            {
                return ((19822 + amount.CalculateTaxPerDoller(87000, .37m)) / 12).RoundOffDoller();
            }
            else if (amount >= 180001)
            {
                return ((54232 + amount.CalculateTaxPerDoller(180000, .45m)) / 12).RoundOffDoller();
            }

            return 0.00m;
        }

        public static bool IsWithin(this decimal value, decimal minimum, decimal maximum)
        {
            return value >= minimum && value <= maximum;
        }

        public static decimal CalculateTaxPerDoller(this decimal amount, decimal slabAmount, decimal centPerDoller)
        {
            return (amount - slabAmount) * centPerDoller;            
        }
    }
}
