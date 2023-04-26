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

        public Stack<Card> cards{get; set;}

        public Player(string name)
        {
            Name = name;
        }
    }
}
