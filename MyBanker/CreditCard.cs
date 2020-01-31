using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public abstract class CreditCard
    {
        /// <summary>
        /// The Prefix of the credit card
        /// Determines the first numbers in the cardnumber
        /// </summary>
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

        /// <summary>
        /// The card number of the credit cards
        /// </summary>
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

        /// <summary>
        /// The persons name the card belongs to
        /// </summary>
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

        /// <summary>
        /// The expiry date of the credit card
        /// </summary>
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

        /// <summary>
        /// The bank account the card can access
        /// </summary>
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

        /// <summary>
        /// The method to pay for a item
        /// the money is withdrawn from the bank account
        /// </summary>
        /// <param name="amount"></param>
        public virtual void Pay(float amount)
        {
            // Implement base Pay method
        }

        /// <summary>
        /// The method to withdraw money from the bank account
        /// </summary>
        /// <param name="amount"></param>
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

        /// <summary>
        /// Returns the card as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"CardHolder: {CardHolderName} CardNumber: {CardNumber} Expiry Date: {ExpiryDate} Account Number: {BankAccount.AccountNumber}";
        }
    }
}
