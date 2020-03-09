using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    public class TraceResult
    {
        /// <summary>
        /// The amount of time it took to reach ipAdress
        /// </summary>
        public int Ms
        {
            get
            {
                return ms;
            }

            private set
            {
                ms = value;
            }
        }

        /// <summary>
        /// The ip adress
        /// </summary>
        public string IpAddress
        {
            get
            {
                return ipAddress;
            }

            private set
            {
                ipAddress = value;
            }
        }

        private int ms;
        private string ipAddress;

        public TraceResult(int ms, string ipAddress)
        {
            Ms = ms;
            IpAddress = ipAddress;
        }


    }
}
