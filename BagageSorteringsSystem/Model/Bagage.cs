namespace BagageSorteringsSystem.Model
{
    public class Bagage
    {
		/// <summary>
		/// The brand of the bagage
		/// </summary>
		public string Brand
		{
			get { return brand; }
			private set { brand = value; }
		}

		/// <summary>
		/// The color of the bagage
		/// </summary>
		public Color Color
		{
			get
			{
				return color;
			}

			private set
			{
				color = value;
			}
		}

		/// <summary>
		/// The weight of the bagage
		/// </summary>
		public float Kilogram
		{
			get
			{
				return kilogram;
			}

			private set
			{
				kilogram = value;
			}
		}

		/// <summary>
		/// The sticker representing where the bagage has to go
		/// </summary>
		public Sticker Sticker
		{
			get
			{
				return sticker;
			}

			private set
			{
				sticker = value;
			}
		}

		private string brand;
		private Color color;
		private float kilogram;
		private Sticker sticker;

		public Bagage(string brand, Color color, float weight)
		{
			Brand = brand;
			Color = color;
			Kilogram = weight;
			Sticker = null;
		}

		/// <summary>
		/// Sets a sticker on the bagage
		/// </summary>
		/// <param name="gateId"></param>
		public void SetSticker(uint gateId)
		{
			Sticker = new Sticker(gateId);
		}
	}
}
