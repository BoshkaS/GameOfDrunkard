using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrunkard
{
    public class Card : IComparable<Card>
    {
        public Suit Suit { get; }

        public Value Value { get; }

        public Player Player { get; set; }

        public Card (Value value, Suit suit)
        {
            Suit = suit;
            Value = value;
            Player = null;
        }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
        public int CompareTo(Card other)
        {
            int valueComparison = Value.CompareTo(other.Value);
            return valueComparison != 0 ? valueComparison : Suit.CompareTo(other.Suit);
        }
    }
}
