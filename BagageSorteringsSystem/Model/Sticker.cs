using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSorteringsSystem.Model
{
    public class Sticker
    {
        /// <summary>
        /// The gate id
        /// </summary>
        public uint GateId
        {
            get
            {
                return gateId;
            }

            private set
            {
                gateId = value;
            }
        }

        private uint gateId;

        public Sticker(uint gateId)
        {
            GateId = gateId;
        }
    }
}
