using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    class SortePerGame : Game
    {
        public SortePerGame(Player[] players) : base(new SortePerDeck(), players)
        {

        }

        public override void PlayerTakeTurn(int indexCard)
        {
            
        }

        public override void ChangePlayer()
        {
            ChangeToNextPlayer();
        }

        public override bool HasGameEnded()
        {
            return (CurrentPlayer.Cards.Count == 1 && CurrentPlayer.Cards[0].Value == 0);
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
    }
}
