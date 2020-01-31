using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public abstract class BankAccount
    {
        /// <summary>
        /// The name of the bank
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                name = value;
            }
        }

        /// <summary>
        /// The Register Number for the Bank account
        /// </summary>
        public string RegisterNumber
        {
            get
            {
                return registerNumber;
            }

            private set
            {
                registerNumber = value;
            }
        }

        /// <summary>
        /// The Account Number for the bank account
        /// </summary>
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }

            private set
            {
                accountNumber = value;
            }
        }

        private string name;
        private string registerNumber;
        private string accountNumber;

        /// <summary>
        /// Creates a bank account from a bank name, registernumber and how many digits the account number should be of
        /// </summary>
        /// <param name="name"></param>
        /// <param name="registerNumber"></param>
        /// <param name="amountOfDigits"></param>
        public BankAccount(string name, string registerNumber, int amountOfDigits)
        {
            Name = name;
            RegisterNumber = registerNumber;

            GenerateAccountNumber(amountOfDigits);
        }

        /// <summary>
        /// Generates an account number from the amount of digits
        /// </summary>
        /// <param name="amountOfDigits"></param>
        private void GenerateAccountNumber(int amountOfDigits)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int remaining = (amountOfDigits - RegisterNumber.Length)-1;
            AccountNumber = RegisterNumber;

            for (int i = 0; i < remaining; i++)
            {
                AccountNumber += rnd.Next(0, 9);
            }
        }



    }
}
