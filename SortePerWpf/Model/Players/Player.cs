using System;
using System.Collections.Generic;
using SortePerWpf.Model.Cards;

namespace SortePerWpf.Model.Players
{
	/// <summary>
	/// TODO: Make as abstract, only used for testing purpose
	/// </summary>
    public class Player : List<Card>
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

		private Random random;
		private string name;

		/// <summary>
		/// Construct a player with a name
		/// </summary>
		/// <param name="name"></param>
		public Player(string name)
		{
			Random = new Random(Guid.NewGuid().GetHashCode());
			Name = name;
		}

		/// <summary>
		/// Shuffle the players hand
		/// </summary>
		public void Shuffle()
		{
			// Shuffle
			int curIndex = this.Count;
			while (curIndex > 1)
			{
				curIndex--;

				int rndIndex = Random.Next(curIndex + 1);
				Card val = this[rndIndex];
				this[rndIndex] = this[curIndex];
				this[curIndex] = val;
			}
		}

	}
}
