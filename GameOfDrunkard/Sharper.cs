using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrunkard
{
    public class Sharper
    {
        private readonly Deck deck; // deck field

        public Sharper(int amount) // constructor
        {
            deck = new Deck(amount); // create new deck with specified amount
        }

        public void Shuffle() // method to shuffle the deck
        {
            Random random = new Random(); // create new instance of Random class
            int n = deck.Cards.Count; // get number of cards in deck

            while (n > 1) // while there are more than 1 cards in deck
            {
                n--; // decrement n
                int k = random.Next(n + 1); // generate random number between 0 and n (inclusive)
                Card card = deck.Cards[k]; // get card at index k
                deck.Cards[k] = deck.Cards[n]; // set card at index k to card at index n
                deck.Cards[n] = card; // set card at index n to the card previously at index k
            }

            foreach (Card card in deck.Cards) // for each card in the deck
            {
                Console.WriteLine(card + " "); // output the card to the console
            }
        }

        public Card DrawCard() // method to draw a card from the deck
        {
            if (deck.Cards.Count == 0) // if there are no cards in the deck
            {
                throw new InvalidOperationException("The deck is empty."); // throw an exception
            }

            Card card = deck.Cards[0]; // get the first card in the deck
            deck.Cards.RemoveAt(0); // remove the card from the deck
            return card; // return the card
        }
    }

}
