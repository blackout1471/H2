using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    public abstract class Game
    {
		public Deck GameDeck
		{
			get { return gameDeck; }
			private set { gameDeck = value; }
		}
		private Deck gameDeck;

		public List<Player> Players
		{
			get { return players; }
			private set { players = value; }
		}
		private List<Player> players;

		public int CurrentPlayerIndex
		{
			get { return currentPlayerIndex; }
			private set { currentPlayerIndex = value; }
		}
		private int currentPlayerIndex;

		public Player CurrentPlayer => GetPlayerAtIndex(CurrentPlayerIndex);
		public Player NextPlayer => (CurrentPlayerIndex + 1 >= Players.Count) ? GetPlayerAtIndex(0) : GetPlayerAtIndex(CurrentPlayerIndex + 1);

		public Game(Deck deck, Player[] gamePlayers)
		{
			GameDeck = deck;
			Players = gamePlayers.ToList();
		}

		public void SetCurrentPlayer(int index)
		{
			if (index >= Players.Count)
				index = 0;

			CurrentPlayerIndex = index;
		}

		public Player GetPlayerAtIndex(int index)
		{
			if (index >= Players.Count)
				throw new IndexOutOfRangeException("Player do not exist");

			return Players[index];
		}

		public abstract string StartGameMessage();
		public abstract string PlayerTakeTurnMessage();
		public abstract string ChangePlayerMessage();
		public abstract string GameHasEndedMessage();

		public abstract void StartGame();

		public abstract void PlayerTakeTurn();

		public abstract void ChangePlayer();

		public abstract bool HasGameEnded();

	}
}
