using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortePerWpf.Model.Decks;
using SortePerWpf.Model.Cards;

namespace SortePerWpf.Model
{

	/// <summary>
	/// Factory used to generate decks.
	/// Is a singleton object
	/// </summary>
    public class DeckFactory
    {

		// Singleton factory
		public static DeckFactory Instance
		{
			get 
			{
				if (instance == null)
					instance = new DeckFactory();

				return instance; 
			}
		}
		private static DeckFactory instance;

		private DeckFactory()
		{

		}

		/// <summary>
		/// Create a list of playing cards
		/// </summary>
		/// <param name="duplicates"></param>
		/// <returns></returns>
		private List<Card> CreateListOfPlayingCards(uint duplicates)
		{
			List<Card> cardsTemplate = new List<Card>();
			List<Card> cardList = new List<Card>();

			for (int i = 0; i < 12; i++)
				cardsTemplate.Add(new Card((byte)i));

			for (int i = 0; i < duplicates + 1; i++)
				cardList.AddRange(cardsTemplate);

			return cardList;
			
		}

		/// <summary>
		/// Create a Sorte Per Deck
		/// </summary>
		/// <returns></returns>
		public Deck CreateSortePerDeck()
		{
			// Template cards
			List<Card> cards = CreateListOfPlayingCards(0);
			cards.Remove(cards.Find(x => x.Value == 12));

			// Create as sortePer deck
			Deck deck = new Deck();
			for (int i = 0; i < cards.Count; i++)
			{
				deck.Enqueue(new SortePerCard(cards[i].Value, SortePerCardColor.Black));
				deck.Enqueue(new SortePerCard(cards[i].Value, SortePerCardColor.Red));
			}
			deck.Enqueue(new SortePerCard(12, SortePerCardColor.Black));

			return deck;
		}

	}
}
