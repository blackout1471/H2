using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    /// <summary>
    /// A Maestro card is used by persons over 18
    /// and can be used international
    /// </summary>
    public class MaestroCard : CreditCard, IUseInternational
    {
        private static readonly string[] prefixes =
        {
            "5018",
            "5020",
            "5038",
            "5893",
            "6304",
            "6759",
            "6761",
            "6762",
            "6763"
        };

        public MaestroCard(string cardHolderName, int age, BankAccount account) : base(19, prefixes, cardHolderName, age, DateTime.Now.AddMonths(68), account)
        {
        }

        public float DrawMoneyInternational(float amount)
        {
            // Draw International
            return 0;
        }

        public void PayInternational(float amount)
        {
            // pay international
        }

        protected override bool AllowedToGetCard(int age)
        {
            return (age >= 18);
        }

        public override string ToString()
        {
            return $"Maestro Card {base.ToString()}";
        }
    }
}
