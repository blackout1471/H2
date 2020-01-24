using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    class SortePerGame : Game
    {
        public SortePerGame(Player[] players) : base(new SortePerDeck(), players) {}

        private void CheckIfPlayerHasPairs()
        {
            List<Card> removingCards = new List<Card>();

            foreach (Card c1 in CurrentPlayer.Cards)
                foreach (Card c2 in CurrentPlayer.Cards)
                    if (c1 != c2)
                        if (c1.Value == c2.Value)
                            if (removingCards.Find(x => x.Value == c1.Value) != null)
                                removingCards.Add(c1);

            foreach (Card c1 in removingCards)
                CurrentPlayer.RemoveCardFromPlayer(c1);

            removingCards.Clear();
        }

        public override void PlayerTakeTurn()
        {
            bool validatedInput = false;
            int cardIndex = 0;

            while (!validatedInput)
            {
                cardIndex = CurrentPlayer.GetUserInput();

                if (cardIndex < NextPlayer.Cards.Count)
                    validatedInput = true;
            }

            Card cardTaken = NextPlayer.RemoveCardFromPlayer(cardIndex);
            CurrentPlayer.AddCardToPlayer(cardTaken);
            CheckIfPlayerHasPairs();
            CurrentPlayer.ShuffleHand();

        }

        public override void ChangePlayer()
        {
            SetCurrentPlayer(CurrentPlayerIndex + 1);
        }

        public override bool HasGameEnded()
        {
            return (CurrentPlayer.Cards.Count == 1 && CurrentPlayer.Cards.Any(x => x.Value == 0));
        }

        public override void StartGame()
        {
            GameDeck.ShuffleCards();

            int curPlayerIndex = 0;

            while (!GameDeck.HasAllCardsBeenDrawn())
            {
                Players[curPlayerIndex].AddCardToPlayer(GameDeck.RemoveTopCard());

                if (curPlayerIndex == Players.Count - 1)
                    curPlayerIndex = 0;
                else
                    curPlayerIndex++;
            }
        }

        public override string StartGameMessage()
        {
            string s = "Players in this game:\n";

            foreach (Player p in Players)
                s += string.Format("Player: {0}\n", p.Name);

            return s;
        }

        public override string PlayerTakeTurnMessage()
        {
            string s = "";
            s += string.Format("It is player: {0}'s turn\nChoose a card between {1}-{2} from {3}\n", CurrentPlayer.Name, 0, NextPlayer.Cards.Count-1, NextPlayer.Name);
            s += string.Format("Your hand is:\n{0}", CurrentPlayer.GetHandAsString());
            return s;
        }

        public override string ChangePlayerMessage()
        {
            return string.Format("{0} drew {1}", CurrentPlayer.Name, CurrentPlayer.LastDrawnCard.ToString());
        }

        public override string GameHasEndedMessage()
        {
            return string.Format("The loser was {0} with the hand: {1}", CurrentPlayer.Name, CurrentPlayer.GetHandAsString());
        }
    }
}
