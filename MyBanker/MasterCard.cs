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
        // The prefixes defined to generate a cardnumber
        private static string[] prefixes =
        {
            "51",
            "52",
            "53",
            "54",
            "55"
        };

        /// <summary>
        /// the daily limit that can be used on the card
        /// </summary>
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

        /// <summary>
        /// The current daily limit
        /// </summary>
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

        /// <summary>
        /// The max monthly use of the card
        /// </summary>
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

        /// <summary>
        /// The current monthly limit which has been used
        /// </summary>
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

        /// <summary>
        /// Create a mastercard from a persons name, age and link a bank account
        /// </summary>
        /// <param name="cardHolderName"></param>
        /// <param name="age"></param>
        /// <param name="account"></param>
        public MasterCard(string cardHolderName, int age, BankAccount account) : base(16, prefixes, cardHolderName, age, DateTime.Now.AddMonths(60), account)
        {
        }

        /// <summary>
        /// Whether the daily limit has been hit
        /// </summary>
        /// <returns></returns>
        public bool HasDailyLimitOccured()
        {
            return (CurrentDailyLimit < MaxDailyLimit);
        }

        /// <summary>
        /// Whether the monthly limit has been hit
        /// </summary>
        /// <returns></returns>
        public bool HasMonthlyLimitOccured()
        {
            return (CurrentMonthlyLimit < MaxMonthlyLimit);
        }

        /// <summary>
        /// Pay online, the amount will be withdrawn from the bankaccount
        /// </summary>
        /// <param name="amount"></param>
        public void PayOnline(float amount)
        {
            // Pay online implementation
        }

        /// <summary>
        /// Whether the age specified is valid for the card
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        protected override bool AllowedToGetCard(int age)
        {
            return true;
        }

        /// <summary>
        /// The masterCard returned as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Master Card {base.ToString()}";
        }
    }
}
