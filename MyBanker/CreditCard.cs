using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public abstract class CreditCard
    {
        public string Prefix
        {
            get
            {
                return prefix;
            }

            private set
            {
                prefix = value;
            }
        }
        public string CardNumber
        {
            get
            {
                return cardNumber;
            }

            private set
            {
                cardNumber = value;
            }
        }
        public string CardHolderName
        {
            get
            {
                return cardHolderName;
            }

            private set
            {
                cardHolderName = value;
            }
        }
        public DateTime ExpiryDate
        {
            get
            {
                return expiryDate;
            }

            private set
            {
                expiryDate = value;
            }
        }
        public BankAccount BankAccount
        {
            get
            {
                return bankAccount;
            }

            private set
            {
                bankAccount = value;
            }
        }

        private string prefix;
        private string cardNumber;
        private string cardHolderName;
        private DateTime expiryDate;
        private BankAccount bankAccount;

        /// <summary>
        /// Creates a Credit card
        /// throw argumentException if user is not allowed
        /// to get card
        /// </summary>
        /// <param name="amountOfDigits"></param>
        /// <param name="allowedPrefixes"></param>
        /// <param name="cardHolderName"></param>
        /// <param name="age"></param>
        /// <param name="expiryDate"></param>
        /// <param name="account"></param>
        public CreditCard(int amountOfDigits, string[] allowedPrefixes, string cardHolderName, int age, DateTime expiryDate, BankAccount account)
        {
            if (!AllowedToGetCard(age))
                throw new ArgumentException("Not allowed to get card");

            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            Prefix = allowedPrefixes[rnd.Next(0, allowedPrefixes.Length - 1)];
            GenerateCardNumber(amountOfDigits, allowedPrefixes);
            CardHolderName = cardHolderName;
            ExpiryDate = expiryDate;
            BankAccount = account;
        }

        public virtual void Pay(float amount)
        {
            // Implement base Pay method
        }

        public virtual void DrawMoney(float amount)
        {
            // Implement base Draw method
        }

        /// <summary>
        /// Whether the specified age is allowed to get the card
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        protected abstract bool AllowedToGetCard(int age);

        /// <summary>
        /// Generates a card number from the amount of digits
        /// and the allowed prefixes defined in sub class
        /// </summary>
        /// <param name="amountOfDigits"></param>
        /// <param name="allowedPrefixes"></param>
        private void GenerateCardNumber(int amountOfDigits, string[] allowedPrefixes)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int remaining = (amountOfDigits - Prefix.Length) - 1;
            CardNumber = Prefix;

            for (int i = 0; i < remaining; i++)
            {
                CardNumber += rnd.Next(0, 9);
            }
        }

        public override string ToString()
        {
            return $"CardHolder: {CardHolderName} CardNumber: {CardNumber} Expiry Date: {ExpiryDate} Account Number: {BankAccount.AccountNumber}";
        }
    }
}
