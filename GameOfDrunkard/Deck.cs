using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrunkard
{
    public class Deck
    {
        public List<Card> Cards { get; set; }
        public int Amount { get; set; }

        public Deck (int amount)
        {
            Amount = (amount == 36 || amount == 52)? amount : 0;
            Cards = new List<Card>();

            List<Card> cards = new List<Card>();

            foreach(Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value value in Enum.GetValues(typeof(Value)))
                {
                    cards.Add(new Card(value, suit));
                }
            }
            if (amount == 36) Cards = cards.Where(x => (int)x.Value >= 6).ToList();

            else if (amount == 52) Cards = cards;
        }
    }
}
