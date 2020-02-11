using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerWpf.Model.Cards
{
    public enum SortePerCardColor
    {
        Red,
        Black
    }

    public class SortePerCard : Card
    {

        /// <summary>
        /// The color of the card
        /// </summary>
        public SortePerCardColor Color
        {
            get { return color; }
            private set { color = value; }
        }
        private SortePerCardColor color;


        /// <summary>
        /// Construct a sortePerCard
        /// </summary>
        /// <param name="value"></param>
        public SortePerCard(byte value, SortePerCardColor color) : base(value)
        {
            Color = color;
        }
    }
}
