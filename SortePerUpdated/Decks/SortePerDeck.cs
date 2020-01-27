using System.Collections.Generic;

namespace SortePerUpdated
{
    public class SortePerDeck : Deck
    {
        /// <summary>
        /// Generates the cards needed for SortePer
        /// </summary>
        public SortePerDeck() : base()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardColor.Red, 0, "SortePer"),

                new Card(CardColor.Red, 1, "Lion"),
                new Card(CardColor.Red, 2, "Elephant"),
                new Card(CardColor.Red, 3, "Monkey"),
                new Card(CardColor.Red, 4, "Snake"),
                new Card(CardColor.Red, 5, "Snail"),
                new Card(CardColor.Red, 6, "Bee"),
                new Card(CardColor.Red, 7, "Giraff"),
                new Card(CardColor.Red, 8, "Pinguin"),
                new Card(CardColor.Red, 9, "Dog"),
                new Card(CardColor.Red, 10, "Bird"),
                new Card(CardColor.Red, 11, "Sheep"),
                new Card(CardColor.Red, 12, "Hedhehog"),
                new Card(CardColor.Red, 13, "Turtle"),
                new Card(CardColor.Red, 14, "Worm"),
                new Card(CardColor.Red, 15, "Dinosaur"),

                new Card(CardColor.Black, 1, "Lion"),
                new Card(CardColor.Black, 2, "Elephant"),
                new Card(CardColor.Black, 3, "Monkey"),
                new Card(CardColor.Black, 4, "Snake"),
                new Card(CardColor.Black, 5, "Snail"),
                new Card(CardColor.Black, 6, "Bee"),
                new Card(CardColor.Black, 7, "Giraff"),
                new Card(CardColor.Black, 8, "Pinguin"),
                new Card(CardColor.Black, 9, "Dog"),
                new Card(CardColor.Black, 10, "Bird"),
                new Card(CardColor.Black, 11, "Sheep"),
                new Card(CardColor.Black, 12, "Hedhehog"),
                new Card(CardColor.Black, 13, "Turtle"),
                new Card(CardColor.Black, 14, "Worm"),
                new Card(CardColor.Black, 15, "Dinosaur"),

            };
            Cards = new Stack<Card>(cards);
        }
    }
}