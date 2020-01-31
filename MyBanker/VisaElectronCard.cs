using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    /// <summary>
    /// Visa electron card can be used by persons over 15
    /// can be used international
    /// it has a monthly limit
    /// </summary>
    public class VisaElectronCard : CreditCard, IUseInternational, IMaxUsePerMonth
    {
        /// <summary>
        /// The available prefixes which will be used to generate a cardnumber
        /// </summary>
        private static string[] prefixes =
        {
            "4026",
            "417500",
            "4508",
            "4844",
            "4913",
            "4917"
        };

        /// <summary>
        /// The monthly limit of the card
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
        /// The current monthly limit
        /// </summary>
        public float CurrentMonthlyUsed
        {
            get
            {
                return currentMonthlyUsed;
            }

            private set
            {
                currentMonthlyUsed = value;
            }
        }

        private float maxMonthlyLimit;
        private float currentMonthlyUsed;

        /// <summary>
        /// Creates a visa electron card froma name, age and a bank account
        /// </summary>
        /// <param name="cardHolderName"></param>
        /// <param name="age"></param>
        /// <param name="account"></param>
        public VisaElectronCard(string cardHolderName, int age, BankAccount account) : base(16, prefixes, cardHolderName, age, DateTime.Now.AddMonths(60), account)
        {
        }

        /// <summary>
        /// Withdraw money from an international place
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public float DrawMoneyInternational(float amount)
        {
            // Draw Money International
            return 0;
        }

        /// <summary>
        /// Whether the monthly limit has been hits
        /// </summary>
        /// <returns></returns>
        public bool HasMonthlyLimitOccured()
        {
            return (CurrentMonthlyUsed < MaxMonthlyLimit);
        }

        /// <summary>
        /// The method used to pay in a international place
        /// </summary>
        /// <param name="amount"></param>
        public void PayInternational(float amount)
        {
            // Pay International

        }

        /// <summary>
        /// whether a specified age is allowed to get the card
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        protected override bool AllowedToGetCard(int age)
        {
            return (age > 15);
        }

        /// <summary>
        /// Returns the visa electron card as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Visa Electron {base.ToString()}";
        }
    }
}
