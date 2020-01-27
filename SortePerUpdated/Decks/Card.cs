namespace SortePerUpdated
{
    public enum CardColor
    {
        Black,
        Red
    }

    public struct Card
    {
        public byte Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public CardColor Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        private byte value;
        private CardColor color;
        private string name;

        public Card(CardColor color, byte value, string name) : this()
        {
            Color = color;
            Value = value;
            Name = name;
        }

        public bool SameCardGenre(Card c2)
        {
            return (Value == c2.Value);
        }

        public static bool operator ==(Card c1, Card c2)
        {
            return (c1.Color == c2.Color &&
                    c1.Value == c2.Value &&
                    c1.Name == c2.Name);
        }

        public static bool operator !=(Card c1, Card c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Name, Value, Color);
        }
    }


}
