using System.Collections.Generic;
using System;

namespace SortePer
{
    public abstract class Deck
    {
        public List<Card> Cards
        {
            get { return cards; }
            private set { cards = value; }
        }
        public int CardAmount
        {
            get { return cardAmount; }
            private set { cardAmount = value; }
        }
        public string[] CardNames
        {
            get { return cardNames; }
            private set { cardNames = value; }
        }

        private List<Card> cards;
        private int cardAmount;
        private string[] cardNames;

        public Deck(int amount) 
        {
            CardAmount = amount;
            Cards = new List<Card>(CardAmount);
            CardNames = SetupCardNames();
            SetupCards();
        }

        public bool HasAllCardsBeenDrawn()
        {
            return (Cards.Count == 0) ? true : false;
        }

        /// <summary>
        /// Shuffle the current deck
        /// </summary>
        public void ShuffleCards()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            int curIndex = Cards.Count;
            while (curIndex > 1)
            {
                curIndex--;

                int rndIndex = rnd.Next(curIndex + 1);
                Card val = Cards[rndIndex];
                Cards[rndIndex] = Cards[curIndex];
                Cards[curIndex] = val;
            }
        }

        public void AddCardToTopDeck(Card card)
        {
            if (Cards.Count >= CardAmount)
                throw new ArgumentOutOfRangeException("Too Many Cards, cannot add anymore");

            if (card.Value < 0 || card.Value >= CardNames.Length)
                throw new IndexOutOfRangeException("No Name Was Found");


            card.Name = CardNames[card.Value];
            Cards.Add(card);
        }

        public Card RemoveTopCard()
        {
            return RemoveCardFromDeck(Cards.Count - 1);
        }

        public Card RemoveBottomCard()
        {
            return RemoveCardFromDeck(0);
        }

        public Card RemoveCardFromDeck(int cardIndex)
        {
            if (cardIndex < 0 || cardIndex >= Cards.Count)
                throw new IndexOutOfRangeException("The index doesn't exists");

            Card removedCard = Cards[cardIndex];
            Cards.RemoveAt(cardIndex);

            return removedCard;
        }

        public Card RemoveCardFromDeck(Card card)
        {
            Card removeCard = Cards.Find(x => x == card);

            if (removeCard == null)
                throw new IndexOutOfRangeException("The card does not exist");

            Cards.Remove(removeCard);
            return removeCard;
        }

        /// <summary>
        /// Setup the card game, this method will be called when
        /// The deck is constructed.
        /// </summary>
        protected abstract void SetupCards();

        /// <summary>
        /// Return a list with the unique card names
        /// the names will be linked againt the 
        /// index of the name, and the value of the card
        /// </summary>
        /// <returns></returns>
        protected abstract string[] SetupCardNames();
    }
}
