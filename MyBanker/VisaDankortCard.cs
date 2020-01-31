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
        // The prefixes used to generate a cardnumber
        private static string[] prefixes =
        {
            "4"
        };

        /// <summary>
        /// The max daily limit allowed
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

        /// <summary>
        /// Create a visa dankort card from a persons name, age and a bank accoutn which will be linked
        /// </summary>
        /// <param name="cardHolderName"></param>
        /// <param name="age"></param>
        /// <param name="account"></param>
        public VisaDankortCard(string cardHolderName, int age, BankAccount account) : base(16, prefixes, cardHolderName, age, DateTime.Now.AddMonths(60), account)
        {
        }

        /// <summary>
        /// Has the daily limit been hit
        /// </summary>
        /// <returns></returns>
        public bool HasDailyLimitOccured()
        {
            return (CurrentDailyUsed < MaxDailyLimit);
        }

        /// <summary>
        /// Whether the age specified is valid for the card
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        protected override bool AllowedToGetCard(int age)
        {
            return (age > 18);
        }

        /// <summary>
        /// The visa dankort returned as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Visa Dankort {base.ToString()}";
        }
    }
}
