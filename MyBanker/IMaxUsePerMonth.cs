using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    /// <summary>
    /// Interface to see if credit card has hit monthly limit
    /// </summary>
    public interface IMaxUsePerMonth
    {
        bool HasMonthlyLimitOccured();
    }
}
