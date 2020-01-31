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
        // The prefixes used to generate card numbers
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

        /// <summary>
        /// Create a maestro card from the persons name, age and a bank account
        /// which will be linked
        /// </summary>
        /// <param name="cardHolderName"></param>
        /// <param name="age"></param>
        /// <param name="account"></param>
        public MaestroCard(string cardHolderName, int age, BankAccount account) : base(19, prefixes, cardHolderName, age, DateTime.Now.AddMonths(68), account)
        {
        }

        /// <summary>
        /// Method to withdraw money from a international place
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public float DrawMoneyInternational(float amount)
        {
            // Draw International
            return 0;
        }

        /// <summary>
        /// Method to pay for a item in a international place
        /// </summary>
        /// <param name="amount"></param>
        public void PayInternational(float amount)
        {
            // pay international
        }

        /// <summary>
        /// Whether the age specified is valid for the card
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        protected override bool AllowedToGetCard(int age)
        {
            return (age >= 18);
        }

        /// <summary>
        /// The maestro card as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Maestro Card {base.ToString()}";
        }
    }
}
