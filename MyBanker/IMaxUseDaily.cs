using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    /// <summary>
    /// Interface to see if creditcard has hit the daily limit use
    /// </summary>
    public interface IMaxUseDaily
    {
        bool HasDailyLimitOccured();
    }
}
