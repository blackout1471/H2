namespace SortePer
{
    public enum CardColor
    {
        Black,
        Red
    };

    public struct Card
    {
        public byte Value;
        public CardColor Color;
        public string Name;

        public static bool operator ==(Card c1, Card c2)
        {
            if (c1.Color == c2.Color &&
                c1.Value == c2.Value)
                return true;

            return false;
        }

        public static bool operator !=(Card c1, Card c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Name, Value, Color);
        }
    };
}