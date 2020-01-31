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
        private static string[] prefixes =
        {
            "2400"
        };

        public HaeveKortCard(string cardHolderName, int age, BankAccount account) : base(16, prefixes, cardHolderName, age, DateTime.MaxValue, account)
        {
        }

        protected override bool AllowedToGetCard(int age)
        {
            return (age < 18);
        }

        public override string ToString()
        {
            return $"Haeve Kort {base.ToString()}";
        }
    }
}
