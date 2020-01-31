using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    /// <summary>
    /// Creates a nordea bank account
    /// </summary>
    public class NordeaBankAccount : BankAccount
    {
        /// <summary>
        /// Creates a nordea bank account
        /// </summary>
        public NordeaBankAccount() : base("Nordea", "3520", 14)
        {
        }
    }
}
