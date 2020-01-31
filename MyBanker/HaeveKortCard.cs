using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    /// <summary>
    /// A havekortCard
    /// is able to be used by persons under 18
    /// </summary>
    public class HaeveKortCard : CreditCard
    {
        // The prefixes which is choosen from to generate a card number
        private static string[] prefixes =
        {
            "2400"
        };

        /// <summary>
        /// Create a haevekortCard with the name of the person, the age
        /// and which bank should be linked to the haevekort
        /// </summary>
        /// <param name="cardHolderName"></param>
        /// <param name="age"></param>
        /// <param name="account"></param>
        public HaeveKortCard(string cardHolderName, int age, BankAccount account) : base(16, prefixes, cardHolderName, age, DateTime.MaxValue, account)
        {
        }

        /// <summary>
        /// Whether age specified is valid for the card
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        protected override bool AllowedToGetCard(int age)
        {
            return (age < 18);
        }

        /// <summary>
        /// The haevekort returned as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Haeve Kort {base.ToString()}";
        }
    }
}
