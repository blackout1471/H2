using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.turd
{
    public abstract class Turd
    {
        /// <summary>
        /// The color of the turd
        /// </summary>
        public Color Color
        {
            get
            {
                return color;
            }

            private set
            {
                color = value;
            }
        }

        /// <summary>
        /// Time it takes to clean the shit in ms
        /// </summary>
        public int TimeToClean
        {
            get
            {
                return timeToClean;
            }

            private set
            {
                timeToClean = value;
            }
        }

        private Color color;

        private int timeToClean;
        public Turd(Color color, int timeToClean)
        {
            Color = color;
            TimeToClean = timeToClean;
        }
    }
}
