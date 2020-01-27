using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerUpdated
{
    public class Hand
    {
        public List<Card> Cards
        {
            get
            {
                return cards;
            }

            set
            {
                cards = value;
            }
        }
        private List<Card> cards;

        public Hand()
        {
            Cards = new List<Card>();
        }
    }
}
