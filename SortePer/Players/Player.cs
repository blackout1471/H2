using System;
using System.Collections.Generic;

namespace SortePer
{
    public abstract class Player
    {
		public string Name
		{
			get { return name; }
			private set { name = value; }
		}
		public List<Card> Cards
		{
			get { return cards; }
			private set { cards = value; }
		}
		private Func<int> InputMethod
		{
			get { return inputMethod; }
			set { inputMethod = value; }
		}
		public Card LastDrawnCard
		{
			get { return lastDrawnCard; }
			private set { lastDrawnCard = value; }
		}

		private Card lastDrawnCard;
		private string name;
		private List<Card> cards;
		private Func<int> inputMethod;

		public Player(string playerName)
		{
			Cards = new List<Card>();
			Name = playerName;
		}

		public void ShuffleHand()
		{
			Random rnd = new Random(Guid.NewGuid().GetHashCode());

			int curIndex = Cards.Count;
			while (curIndex > 1)
			{
				curIndex--;

				int rndIndex = rnd.Next(curIndex + 1);
				Card val = Cards[rndIndex];
				Cards[rndIndex] = Cards[curIndex];
				Cards[curIndex] = val;
			}
		}

		public void AddCardToPlayer(Card card)
		{
			Cards.Add(card);
			LastDrawnCard = card;
		}

		public Card RemoveCardFromPlayer(Card card)
		{
			Card returnCard = Cards.Find(x => x == card);

			if (returnCard == null)
				throw new ArgumentNullException("Card does not exist");

			Cards.Remove(card);
			return returnCard;
		}

		public Card[] RemoveCardsFromPlayer(params Card[] pcards)
		{
			for (int i = 0; i < pcards.Length; i++)
				RemoveCardFromPlayer(pcards[i]);

			return pcards;
		}

		public Card RemoveCardFromPlayer(int index)
		{
			if (index < 0 || index >= Cards.Count)
				throw new IndexOutOfRangeException("The index was not right");

			Card returnCard = Cards[index];
			Cards.RemoveAt(index);

			return returnCard;
		}

		public void SetInputMethod(Func<int> func)
		{
			InputMethod = func;
		}

		public int GetUserInput()
		{
			return InputMethod();
		}

		public string GetHandAsString()
		{
			string s = "";

			for (int i = 0; i < Cards.Count; i++)
			{
				s += Cards[i].ToString() + "\n";
			}

			return s;
		}

	}
}
