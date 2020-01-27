using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerUpdated
{
    public abstract class CardGame
    {
        public List<Player> Players
        {
            get
            {
                return players;
            }

            private set
            {
                players = value;
            }
        }
        public Deck Deck
        {
            get
            {
                return deck;
            }

            private set
            {
                deck = value;
            }
        }
        public Action<string> OutputMethod
        {
            get
            {
                return outputMethod;
            }

            private set
            {
                outputMethod = value;
            }
        }

        private Action<string> outputMethod;
        private Deck deck;
        private List<Player> players;

        public CardGame(Action<string> _outputMethod, Deck _deck, params Player[] players)
        {
            Deck = _deck;
            Players = players.ToList();
            OutputMethod = _outputMethod;
        }

        protected string GetPlayerNames()
        {
            string names = "";
            for (int i = 0; i < Players.Count; i++)
                names += Players[i].Name + "\n";

            return names;
        }

        /// <summary>
        /// Returns whether the game has ended
        /// </summary>
        /// <returns></returns>
        protected abstract bool HasGameEnded();

        /// <summary>
        /// Called when the game starts up
        /// </summary>
        protected abstract void GameStart();

        /// <summary>
        /// Called when the game is ending
        /// </summary>
        protected abstract void GameEnded();

        /// <summary>
        /// Called when a player is taking a turn
        /// </summary>
        protected abstract void PlayerTurn();

        /// <summary>
        /// Called to output a message to the gui layer
        /// </summary>
        /// <param name="message"></param>
        protected void OutputAMessage(string message)
        {
            OutputMethod(message);
        }

        /// <summary>
        /// This is the run method of the class
        /// is called when the game should be started
        /// </summary>
        public void StartGame()
        {
            GameStart();

            while (!HasGameEnded())
            {
                PlayerTurn();
            }

            GameEnded();
        }
    }
}
