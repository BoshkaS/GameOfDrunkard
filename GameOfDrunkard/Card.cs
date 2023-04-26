using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrunkard
{
    public class Card
    {
        public Suit Suit { get; }

        public Value Value { get; }

        public Card (Value value, Suit suit)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }
}
