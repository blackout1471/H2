using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    /// <summary>
    /// Interface to make a credit card
    /// able to be used online
    /// </summary>
    public interface IUseOnline
    {
        void PayOnline(float amount);
    }
}
