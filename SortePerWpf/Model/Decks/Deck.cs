using SortePerWpf.Model.Cards;
using System;
using System.Collections.Generic;


namespace SortePerWpf.Model.Decks
{
    /// <summary>
    /// A collection of cards
    /// represented as a deck
    /// </summary>
    public class Deck : Queue<Card>
    {
        /// <summary>
        /// A random class used for shuffle etc.
        /// </summary>
        private Random Random
        {
            get { return random; }
            set { random = value; }
        }
        private Random random;

        public Deck() : base()
        {
            Random = new Random(Guid.NewGuid().GetHashCode());
        }

        /// <summary>
        /// Shuffle the deck
        /// </summary>
        public void Shuffle()
        {
            List<Card> items = new List<Card>(this);
            this.Clear();

            // Shuffle
            int curIndex = items.Count;
            while (curIndex > 1)
            {
                curIndex--;

                int rndIndex = Random.Next(curIndex + 1);
                Card val = items[rndIndex];
                items[rndIndex] = items[curIndex];
                items[curIndex] = val;
            }

            // Enqueue the list
            for (int i = 0; i < items.Count; i++)
            {
                this.Enqueue(items[i]);
            }
        }
    }
}
