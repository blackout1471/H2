using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    /// <summary>
    /// Visa Dankort can be used by persons over 18
    /// it has a daily limit
    /// </summary>
    public class VisaDankortCard : CreditCard, IMaxUseDaily
    {
        private static string[] prefixes =
        {
            "4"
        };

        public float MaxDailyLimit
        {
            get
            {
                return maxDailyLimit;
            }

            private set
            {
                maxDailyLimit = value;
            }
        }
        public float CurrentDailyUsed
        {
            get
            {
                return currentDailyUsed;
            }

            private set
            {
                currentDailyUsed = value;
            }
        }

        private float maxDailyLimit;
        private float currentDailyUsed;

        public VisaDankortCard(string cardHolderName, int age, BankAccount account) : base(16, prefixes, cardHolderName, age, DateTime.Now.AddMonths(60), account)
        {
        }

        public bool HasDailyLimitOccured()
        {
            return (CurrentDailyUsed < MaxDailyLimit);
        }

        protected override bool AllowedToGetCard(int age)
        {
            return (age > 18);
        }

        public override string ToString()
        {
            return $"Visa Dankort {base.ToString()}";
        }
    }
}
