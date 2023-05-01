using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrunkard
{
    public class Player
    {
        public string Name { get; set; }

        public Stack<Card> Cards{get; set;}

        public Player(string name)
        {
            Name = name;
            Cards = new Stack<Card>();
        }

        public override string ToString()
        {
            string result = $"Name of Player is {Name} and player has ";
            foreach(var card in Cards)
            {
                result += $"{card}, ";
            }
            result += "\n\n";
            return result;
        }

    }

}
