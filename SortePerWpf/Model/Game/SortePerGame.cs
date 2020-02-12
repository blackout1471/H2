using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortePerWpf.Model.Cards;
using SortePerWpf.Model.Decks;
using SortePerWpf.Model.Players;

namespace SortePerWpf.Model.Game
{
    public class SortePerGame : GameBase
    {
        /// <summary>
        /// This games deck
        /// </summary>
        public Deck Deck { get => deck; private set => deck = value; }

        /// <summary>
        /// The current player
        /// </summary>
        public Player CurrentPlayer => Players[currentPlayerIndex];

        /// <summary>
        /// The opponent which the current player has to draw from
        /// </summary>
        public Player OpponentPlayer => (currentPlayerIndex - 1 < 0) ? Players[Players.Count - 1] : Players[currentPlayerIndex - 1];

        private Deck deck;
        private int currentPlayerIndex;

        public SortePerGame() : base()
        {
            
        }
        
        /// <summary>
        /// Draw a card from the opponent
        /// based upon an index
        /// </summary>
        /// <param name="index"></param>
        public void DrawFromOpponent(int index)
        {
            CurrentPlayer.DrawCard(OpponentPlayer.RemoveCardFromHand(index));
        }

        /// <summary>
        /// Checks whether the two cards is a match
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public bool IsCardsPair(Card card1, Card card2)
        {
            if (card1.Value == card2.Value)
                return true;

            return false;
        }

        /// <summary>
        /// Draw a card from the opponent
        /// based upon a card
        /// </summary>
        /// <param name="card"></param>
        public void DrawFromOpponent(Card card)
        {
            CurrentPlayer.DrawCard(OpponentPlayer.RemoveCardFromHand(card));
        }

        /// <summary>
        /// Called to change a turn for a player
        /// </summary>
        public override void ChangeTurn()
        {
            ChangeToNextPlayer();
        }

        /// <summary>
        /// Called when ending the game
        /// </summary>
        public override void End()
        {
            
        }

        /// <summary>
        /// Called when starting a game
        /// </summary>
        public override void Start()
        {
            CreateNewDeck();
            AssignPlayerCards();
        }

        #region Game Flow

        /// <summary>
        /// Creates a new deck and shuffles it
        /// </summary>
        private void CreateNewDeck()
        {
            Deck = DeckFactory.Instance.CreateSortePerDeck();
            Deck.Shuffle();
        }

        /// <summary>
        /// Assigns the players the cards
        /// </summary>
        private void AssignPlayerCards()
        {
            int deckCount = Deck.Count;

            for (int i = 0; i < deckCount; i++)
            {
                CurrentPlayer.DrawCard(Deck.Dequeue());

                ChangeToNextPlayer();
            }

            currentPlayerIndex = 0;
        }

        /// <summary>
        /// Changes the player to the next in line
        /// </summary>
        private void ChangeToNextPlayer()
        {
            if (currentPlayerIndex + 1 < Players.Count)
                currentPlayerIndex++;
            else
                currentPlayerIndex = 0;
        }
        #endregion
    }
}
