using System;
using System.Collections.Generic;
using SortePerWpf.Model.Cards;

namespace SortePerWpf.Model.Players
{
	/// <summary>
	/// TODO: Make as abstract, only used for testing purpose
	/// </summary>
    public class Player
    {
		/// <summary>
		/// Random object used to shuffle etc.
		/// </summary>
		private Random Random
		{
			get { return random; }
			set { random = value; }
		}

		/// <summary>
		/// The name of the player
		/// </summary>
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
		/// The current players cards in the hand
		/// </summary>
		public List<Card> Hand { get => hand; private set => hand = value; }

		private Random random;
		private string name;
		private List<Card> hand;

		/// <summary>
		/// Construct a player with a name
		/// </summary>
		/// <param name="name"></param>
		public Player(string name)
		{
			Random = new Random(Guid.NewGuid().GetHashCode());
			Name = name;
			Hand = new List<Card>();
		}

		/// <summary>
		/// Draw a card to your hand
		/// </summary>
		/// <param name="card"></param>
		public void DrawCard(Card card)
		{
			Hand.Add(card);
		}

		/// <summary>
		/// Remove a card from own hand
		/// based on card
		/// </summary>
		/// <param name="card"></param>
		/// <returns>the card which was removed</returns>
		public Card RemoveCardFromHand(Card card)
		{
			Hand.Remove(card);

			return card;
		}

		/// <summary>
		/// Remove card from hand
		/// based on index
		/// </summary>
		/// <param name="index"></param>
		/// <returns>The card which was removed</returns>
		public Card RemoveCardFromHand(int index)
		{
			if (index < 0 || index >= Hand.Count)
				throw new IndexOutOfRangeException($"{index} was out of range in the hand which has {Hand.Count}");

			Card card = Hand[index];
			Hand.Remove(card);

			return card;
		}

		/// <summary>
		/// Shuffle the players hand
		/// </summary>
		public void Shuffle()
		{
			// Shuffle
			int curIndex = Hand.Count;
			while (curIndex > 1)
			{
				curIndex--;

				int rndIndex = Random.Next(curIndex + 1);
				Card val = Hand[rndIndex];
				Hand[rndIndex] = Hand[curIndex];
				Hand[curIndex] = val;
			}
		}

	}
}
