using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerWpf.Model.Cards
{
    public class Card
    {
		/// <summary>
		/// The value of the card
		/// </summary>
		public byte Value
		{
			get { return value; }
			private set { this.value = value; }
		}
		private byte value;

		/// <summary>
		/// Construct the card with a value
		/// </summary>
		/// <param name="value"></param>
		public Card(byte value)
		{
			Value = value;
		}
	}
}
