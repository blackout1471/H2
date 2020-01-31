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
        private static string[] prefixes =
        {
            "4026",
            "417500",
            "4508",
            "4844",
            "4913",
            "4917"
        };

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

        public VisaElectronCard(string cardHolderName, int age, BankAccount account) : base(16, prefixes, cardHolderName, age, DateTime.Now.AddMonths(60), account)
        {
        }

        public float DrawMoneyInternational(float amount)
        {
            // Draw Money International
            return 0;
        }

        public bool HasMonthlyLimitOccured()
        {
            return (CurrentMonthlyUsed < MaxMonthlyLimit);
        }

        public void PayInternational(float amount)
        {
            // Pay International

        }

        protected override bool AllowedToGetCard(int age)
        {
            return (age > 15);
        }

        public override string ToString()
        {
            return $"Visa Electron {base.ToString()}";
        }
    }
}
