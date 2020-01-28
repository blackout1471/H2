using System;
using System.Collections.Generic;
using System.Linq;

namespace SortePerUpdated
{
    public class Player
    {
        /// <summary>
        /// The method attached to get player input
        /// </summary>
        public Func<int> InputMethod
        {
            get
            {
                return inputMethod;
            }

            protected set
            {
                inputMethod = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                name = value;
            }
        }

        /// <summary>
        /// The players "Hand" - cards
        /// </summary>
        public Hand Hand
        {
            get
            {
                return hand;
            }

            private set
            {
                hand = value;
            }
        }

        private Func<int> inputMethod;
        private string name;
        private Hand hand;

        public Player(string _name, Func<int> _inputMethod)
        {
            Name = _name;
            InputMethod = _inputMethod;
            Hand = new Hand();
        }

        public void AddCardToHand(Card card)
        {
            Hand.Cards.Add(card);
        }

        public Card TakeCardFromDeck(Deck deck)
        {
            return deck.Cards.Pop();
        }

        public Card TakeCardFromHand(Hand hand, int index)
        {
            if (index < 0 || index >= hand.Cards.Count)
                throw new IndexOutOfRangeException("The index goes out of range");

            Card card = hand.Cards[index];
            hand.Cards.RemoveAt(index);
            return card;
        }

        /// <summary>
        /// returns all the pairs from the hand given as parameter
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public List<Card> GetPlayerPairFromHand(Hand hand)
        {
            List<Card> cards = new List<Card>();

            foreach (Card c1 in hand.Cards)
                foreach (Card c2 in hand.Cards)
                    if (c1 != c2)
                        if (c1.SameCardGenre(c2))
                            cards.Add(c1);

            return cards;
        }

        public void RemovePairsFromHand()
        {
            List<Card> cards = GetPlayerPairFromHand(Hand);
            RemoveCardsFromHand(cards);
        }

        public Card RemoveCardFromHand(Card card)
        {
            Hand.Cards.Remove(card);
            return card;
        }

        public Card RemoveCardFromHand(int index)
        {
            return RemoveCardFromHand(Hand.Cards[index]);
        }

        public Card[] RemoveCardsFromHand(List<Card> cards)
        {
            foreach (Card card in cards)
                RemoveCardFromHand(card);

            return cards.ToArray();
        }

        public void ShuffleCards(Hand hand)
        {
            hand.Cards = Utils.ShuffleList<Card>(hand.Cards);
        }

        public void ShuffleCards(Deck deck)
        {
            List<Card> cards = deck.Cards.ToList();
            cards = Utils.ShuffleList<Card>(cards);
            deck.Cards = new Stack<Card>(cards);
        }

        /// <summary>
        /// Returns the user input
        /// </summary>
        /// <returns></returns>
        public int GetUserInput()
        {
            return inputMethod();
        }

    }
}
