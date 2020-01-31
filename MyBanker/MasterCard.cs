using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    /// <summary>
    /// Master card can be used by any age
    /// can be used online
    /// it has a limit per month and per day
    /// </summary>
    public class MasterCard : CreditCard, IUseOnline, IMaxUsePerMonth, IMaxUseDaily
    {
        private static string[] prefixes =
        {
            "51",
            "52",
            "53",
            "54",
            "55"
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
        public float CurrentDailyLimit
        {
            get
            {
                return currentDailyLimit;
            }

            private set
            {
                currentDailyLimit = value;
            }
        }
        public float MaxMonthlyLimit
        {
            get
            {
                return maxMonthlyLimit;
            }

            private set
            {
                maxMonthlyLimit = value;
            }
        }
        public float CurrentMonthlyLimit
        {
            get
            {
                return currentMonthlyLimit;
            }

            private set
            {
                currentMonthlyLimit = value;
            }
        }

        private float maxDailyLimit;
        private float currentDailyLimit;
        private float maxMonthlyLimit;
        private float currentMonthlyLimit;

        public MasterCard(string cardHolderName, int age, BankAccount account) : base(16, prefixes, cardHolderName, age, DateTime.Now.AddMonths(60), account)
        {
        }

        public bool HasDailyLimitOccured()
        {
            return (CurrentDailyLimit < MaxDailyLimit);
        }

        public bool HasMonthlyLimitOccured()
        {
            return (CurrentMonthlyLimit < MaxMonthlyLimit);
        }

        public void PayOnline(float amount)
        {
            // Pay online implementation
        }

        protected override bool AllowedToGetCard(int age)
        {
            return true;
        }

        public override string ToString()
        {
            return $"Master Card {base.ToString()}";
        }
    }
}
