using System;
using System.Collections.Generic;
using System.Linq;

namespace SortePerUpdated
{
    public class SortePerGame : CardGame
    {
        /// <summary>
        /// Peek the next player
        /// </summary>
        public Player NextPlayer => (currentPlayerIndex + 1 < Players.Count) ? Players[currentPlayerIndex + 1] : Players[0];

        /// <summary>
        /// The current player
        /// </summary>
        public Player CurrentPlayer => Players[currentPlayerIndex];
        private Random Rnd
        {
            get
            {
                return rnd;
            }

            set
            {
                rnd = value;
            }
        }

        private Random rnd;
        private int currentPlayerIndex = 0;

        public SortePerGame(Action<string> outputMethod, params Player[] players) : base(outputMethod, new SortePerDeck(), players)
        {
            if (players.Length < 2)
                throw new ArgumentException("There should be at least 2 players");

            Rnd = new Random(Guid.NewGuid().GetHashCode());
        }

        private void ShuffleDeck()
        {
            CurrentPlayer.ShuffleCards(Deck);
        }

        /// <summary>
        /// Sets a random player as the current
        /// </summary>
        private void SetRandomCurrentPlayer()
        {
            int rndNumber = Rnd.Next(0, Players.Count);
            currentPlayerIndex = rndNumber;
        }

        private void ChangeToNextPlayer()
        {
            if (currentPlayerIndex + 1 < Players.Count)
                currentPlayerIndex++;
            else
                currentPlayerIndex = 0;
        }

        private void DrawAllCardsFromDeck()
        {
            int cardAmount = Deck.Cards.Count;
            for (int i = 0; i < cardAmount; i++)
            {              
                Card card = CurrentPlayer.TakeCardFromDeck(Deck);
                CurrentPlayer.AddCardToHand(card);
                ChangeToNextPlayer();
            }
        }

        /// <summary>
        /// Returns whether the current player
        /// has lost
        /// </summary>
        /// <returns></returns>
        private bool HasCurrentPlayerLost()
        {
            return (
                CurrentPlayer.Hand.Cards.Count == 1 && 
                CurrentPlayer.Hand.Cards.Any(x => x.Value == 0) && 
                Players.Count <= 2
                );
        }

        /// <summary>
        /// Get player input
        /// and check whether the input is allowed.
        /// Will loop until an input is valid
        /// </summary>
        /// <returns></returns>
        private int GetCardChoiceFromPlayer()
        {
            bool validated = false;
            int index = 0;

            while (!validated)
            {
                index = CurrentPlayer.GetUserInput();

                if (index < NextPlayer.Hand.Cards.Count)
                    validated = true;
            }

            return index;
        }

        private Card DrawCardFromOpponent(int index)
        {
            Card opponentsCard = CurrentPlayer.TakeCardFromHand(NextPlayer.Hand, index);
            CurrentPlayer.AddCardToHand(opponentsCard);
            return opponentsCard;
        }

        /// <summary>
        /// Removes the player from the game
        /// if they have 0 cards
        /// return true if they were removed
        /// and false if not
        /// </summary>
        private bool RemovePlayerIfZeroCards()
        {
            if (CurrentPlayer.Hand.Cards.Count <= 0)
            {
                Players.Remove(CurrentPlayer);
                return true;
            }

            return false;
        }


        protected override void GameEnded()
        {
            OutputAMessage(string.Format("{0} has lost {1}", CurrentPlayer.Name, CurrentPlayer.Hand.Cards[0]));
        }

        protected override void GameStart()
        {
            OutputAMessage(string.Format("Welcome To The Players: \n{0}", GetPlayerNames()));
            SetRandomCurrentPlayer();
            ShuffleDeck();
            DrawAllCardsFromDeck();
        }

        protected override bool HasGameEnded()
        {
            return HasCurrentPlayerLost();
        }

        protected override void PlayerTurn()
        {
            OutputAMessage(""); // newline
            string curName = CurrentPlayer.Name;

            CurrentPlayer.RemovePairsFromHand();
            if (!RemovePlayerIfZeroCards())
            {
                OutputAMessage(string.Format("It is {0}'s turn", curName));
                OutputAMessage(string.Format("Choose a card index between 0-{0} from your opponent", NextPlayer.Hand.Cards.Count - 1));

                int choice = GetCardChoiceFromPlayer();
                Card drawnCard = DrawCardFromOpponent(choice);
                OutputAMessage(string.Format("Player {0} drew {1}", curName, drawnCard));
                CurrentPlayer.ShuffleCards(CurrentPlayer.Hand);

                CurrentPlayer.RemovePairsFromHand();
                RemovePlayerIfZeroCards();
            }

            ChangeToNextPlayer();
        }
    }
}
