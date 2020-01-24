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

		public Player CurrentPlayer => Players[CurrentPlayerIndex];
		public Player PeekNextPlayer => (CurrentPlayerIndex + 1 >= Players.Count - 1) ? Players[0] : Players[CurrentPlayerIndex + 1];

		public Game(Deck deck, Player[] gamePlayers)
		{
			GameDeck = deck;
			Players = gamePlayers.ToList();
		}

		public void SetCurrentPlayer(int playerIndex)
		{
			if (playerIndex > Players.Count - 1 || playerIndex < 0)
				throw new IndexOutOfRangeException("The index of the player does not exist");

			CurrentPlayerIndex = playerIndex;
		}

		public void ChangeToNextPlayer()
		{
			if (CurrentPlayerIndex + 1 > Players.Count -1)
				SetCurrentPlayer(0);
			else
				SetCurrentPlayer(currentPlayerIndex + 1);
		}

		public abstract void StartGame();

		public abstract void PlayerTakeTurn(int indexCard);

		public abstract void ChangePlayer();

		public abstract bool HasGameEnded();

	}
}
