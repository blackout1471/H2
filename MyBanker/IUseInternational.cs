using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    /// <summary>
    /// Interface which makes a credit card able
    /// to be used international
    /// </summary>
    public interface IUseInternational
    {
        void PayInternational(float amount);
        float DrawMoneyInternational(float amount);
    }
}
