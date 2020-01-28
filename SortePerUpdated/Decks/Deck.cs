using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerUpdated
{
    public abstract class Deck
    {
        public Stack<Card> Cards
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
        private Stack<Card> cards;

        public Deck()
        {
            Cards = new Stack<Card>();
        }
    }
}
