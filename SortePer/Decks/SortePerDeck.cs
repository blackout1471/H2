using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    public class SortePerDeck : Deck
    {
        public SortePerDeck() : base(31) {}

        protected override void SetupCards()
        {
            Card sortePerCard = new Card() { Color = CardColor.Black, Value = 0 };
            AddCardToTopDeck(sortePerCard);

            for (int i = 0; i < (CardAmount - 1) / 2; i++)
            {
                Card blackCard = new Card() { Color = CardColor.Black, Value = (byte)(i+1) };
                Card redCard = new Card() { Color = CardColor.Red, Value = (byte)(i+1) };

                AddCardToTopDeck(blackCard);
                AddCardToTopDeck(redCard);
            }
        }

        protected override string[] SetupCardNames()
        {
            string[] names =
            {
                "SortePer",
                "Lion",
                "Elephant",
                "Monkey",
                "Snake",
                "Snail",
                "Bee",
                "Giraff",
                "Pinguin",
                "Dog",
                "Bird",
                "Sheep",
                "Hedhehog",
                "Turtle",
                "Worm",
                "Dinosaur"
            };
            return names;
        }
    }
}
